import { iconsHtml } from './iconsHtml.js'
import { photoDeletion } from './deletePhoto.js'
import { addPhoto } from './addPhoto.js'
import { changePhoto } from './changePhoto.js'

export function main() {
    let thumbnails = document.getElementsByClassName('thumbnails')[0];
    thumbnails.addEventListener("mouseenter", () => {
        if (thumbnails.lastElementChild.tagName === 'FORM') {
            return;
        }
        console.log('append');
        thumbnails.appendChild(iconsHtml.thumbnails());
        addPhoto.main();
    })
    thumbnails.addEventListener("mouseleave", () => {
        if (thumbnails.lastElementChild.tagName === 'FORM') {
            thumbnails.removeChild(thumbnails.lastElementChild);
        }
    })

    let editPhoto = document.getElementsByClassName('edit-photo')[0];
    editPhoto.addEventListener("mouseenter", () => {
        if (editPhoto.lastElementChild.tagName === 'FORM') return;
        editPhoto.appendChild(iconsHtml.editPhoto());
        photoDeletion.main();
        changePhoto.main();
    })
    editPhoto.addEventListener("mouseleave", () => {
        if (editPhoto.lastElementChild.tagName !== 'FORM') return;
        editPhoto.removeChild(editPhoto.lastElementChild);
    })
}