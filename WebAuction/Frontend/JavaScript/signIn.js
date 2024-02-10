document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.log-in-button').addEventListener('click', function (e) {
        e.preventDefault();

        function getQueryStringValue(key) {
            return new URLSearchParams(window.location.search).get(key);
        }

        var returnUrl = getQueryStringValue('returnUrl');

        if (returnUrl) {
            document.getElementById('returnUrlField').value = returnUrl;
        }
        else {
            document.getElementById('returnUrlField').value = "/";
        }

        const form = document.getElementById('signInForm');
        const formData = new FormData(form);

        fetch(form.action, {
            method: 'POST',
            body: formData,
            headers: { 'Accept': 'application/json' }
        })
            .then(response => response.json()) 
            .then(data => {
                if (data.success) {
                    window.location.href = data.redirectUrl;
                } else {
                    document.getElementById('signInMessage').textContent = data.message;
                }
            })
            .catch(error => console.error('Error:', error));
    });
});
