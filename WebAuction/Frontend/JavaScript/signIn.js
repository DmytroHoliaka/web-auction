document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.log-in-button').addEventListener('click', function (e) {
        e.preventDefault();
        const form = document.getElementById('signInForm');
        const formData = new FormData(form);

        fetch(form.action, {
            method: 'POST',
            body: formData,
            headers: {
                'Accept': 'text/plain'
            }
        })
            .then(response => response.text())
            .then(data => {
                document.getElementById('signInMessage').textContent = data;
            })
            .catch(error => console.error('Error:', error));
    });
});