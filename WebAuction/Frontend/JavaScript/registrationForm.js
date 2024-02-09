document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.log-in-button').addEventListener('click', function (e) {
        e.preventDefault();
        const form = document.getElementById('registrationForm');
        const formData = new FormData(form);

        fetch(form.action, {
            method: 'POST',
            body: formData,
            headers: {
                'Accept': 'text/plain'
            }
        })
            .then(response => {
                if (response.ok && response.redirected) {
                    window.location.href = response.url; 
                } else {
                    return response.text();
                }
            })
            .then(data => {
                if (data) {
                    document.getElementById('signInMessage').textContent = data;
                }
            })
            .catch(error => console.error('Error:', error));
    });
});