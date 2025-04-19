window.onload = function () {
  const ui = SwaggerUIBundle({
    url: "/swagger/v1/swagger.json",
    dom_id: '#swagger-ui',
    presets: [SwaggerUIBundle.presets.apis, SwaggerUIStandalonePreset],
    layout: "StandaloneLayout"
  });

  function injectLoginForm() {
    const modal = document.querySelector('.swagger-ui .dialog-ux .modal-ux');

    if (!modal || modal.querySelector('#custom-login-wrapper')) {
      return;
    }

    const loginUI = document.createElement('div');
    loginUI.id = 'custom-login-wrapper';
    loginUI.innerHTML = \`
      <div style="margin: 15px 0 5px 0; padding: 10px; background: #f6f6f6; border: 1px solid #ccc;">
        <h4 style="margin-top: 0;">🔐 Login with Username & Password</h4>
        <input id="custom-username" type="text" placeholder="Username" style="margin: 4px; padding: 6px; width: 90%;" />
        <input id="custom-password" type="password" placeholder="Password" style="margin: 4px; padding: 6px; width: 90%;" />
        <button id="custom-login-button" style="margin: 4px; padding: 6px 10px;">Get Token</button>
      </div>
    \`;

    modal.prepend(loginUI);
  }

  // Listen for modal open
  const observer = new MutationObserver(() => {
    const modalOpen = document.querySelector('.swagger-ui .dialog-ux .modal-ux');
    if (modalOpen) {
      injectLoginForm();
    }
  });

  observer.observe(document.body, { childList: true, subtree: true });

  // Listen for login button
  document.addEventListener('click', function (e) {
    if (e.target && e.target.id === 'custom-login-button') {
      const username = document.getElementById('custom-username').value;
      const password = document.getElementById('custom-password').value;

      fetch('/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
      })
        .then(res => {
          if (!res.ok) throw new Error("Login failed");
          return res.json();
        })
        .then(data => {
          const token = data.token;
          ui.preauthorizeApiKey("Bearer", "Bearer " + token);
          alert("Token applied!");
        })
        .catch(err => alert("Login failed: " + err.message));
    }
  });
};