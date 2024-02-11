import { pageFromLocalStorage } from '../serverInteraction/pageFromLocalStorage.js'

let addPhoto = {}

addPhoto.main = () => {
    console.log('addPhoto')
    let photoInput = document.querySelector('#addPhoto');
    console.log(photoInput.value);
    photoInput.addEventListener('change', async (event) => {
        console.log('file sent');
        let selectedPhoto = event.target.files[0];
        await pushPhotoToLocalStorage(selectedPhoto);
        pageFromLocalStorage.updatePhotos();
    })

    async function pushPhotoToLocalStorage(photoFile) {
        return new Promise((resolve) => {
            const reader = new FileReader();
            reader.onload = function () {
                const base64String = reader.result;
                let photos = JSON.parse(localStorage.getItem('photos'));
                photos.push(base64String);
                localStorage.setItem('photos', JSON.stringify(photos));
                console.log('Local storage:', localStorage);
                console.log('Photos count:', photos.length);
                resolve()
            };
            reader.readAsDataURL(photoFile);
        });
    }
    console.log('leave addPhoto')
}

export { addPhoto }