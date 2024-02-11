document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.log-in-button').addEventListener('click', function (e) {
        e.preventDefault();
        const form = document.getElementById('registrationForm');
        const formData = new FormData(form);

        fetch(form.action, {
            method: 'POST',
            body: formData,
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    window.location.href = data.redirectUrl;
                } else {
                    document.getElementById("signInMessage").textContent = data.message;
                }
            })
            .catch(error => {
                console.error('There was a problem with your fetch operation:', error);
                alert('An error occurred while processing your registration.');
            });
    });
});
