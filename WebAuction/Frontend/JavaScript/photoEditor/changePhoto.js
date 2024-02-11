import { pageFromLocalStorage } from '../serverInteraction/pageFromLocalStorage.js'

let changePhoto = {}

changePhoto.main = () => {
    let photoInput = document.querySelector('#changePhoto');
    photoInput.addEventListener('change', async (event) => {
        let selectedPhoto = event.target.files[0];
        let base64String = await getBase64String(selectedPhoto);

        let thumbnailsBlock = document.querySelector('.thumbnails');
        let curThumbnailIndex = pageFromLocalStorage.getCurrentPhotoIndex();
        let curElement = thumbnailsBlock.children[curThumbnailIndex];
        curElement.src = base64String;

        let photos = JSON.parse(localStorage.getItem('photos'));
        photos[curThumbnailIndex] = base64String;
        localStorage.setItem('photos', JSON.stringify(photos));

        let currentPhoto = document.querySelector('.currentPhoto');
        currentPhoto.src = base64String;
    })

    async function getBase64String(file) {
        const reader = new FileReader();
        let base64String;

        const promise = new Promise((resolve) => {
            reader.onload = function (e) {
                base64String = e.target.result;
                resolve();
            };
        });

        reader.readAsDataURL(file);
        await promise;
        return base64String;
    }
}

export {changePhoto }