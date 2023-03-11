


function getCurrentUrl() {
    return window.location.href
}

const url = getCurrentUrl()
if (url == 'https://shyam123.bsite.net/') {
    window.onload = (event) => {
        const form = document.getElementById('form');


        if (form.style.display === 'none') {
            // 👇️ this SHOWS the form
            form.style.display = 'block';
        } else {
            form.style.display = 'none'
        }
    }
} else {
    window.onload = (event) => {
        const form = document.getElementById('form');


        if (form.style.display === 'none') {
            // 👇️ this SHOWS the form
            form.style.display = 'block';
        } else {
            form.style.display = 'block'
        }
    }
}



const btn = document.getElementById('btn');

btn.addEventListener('click', () => {
    const form = document.getElementById('form');

    if (form.style.display === 'none') {
        // 👇️ this SHOWS the form
        form.style.display = 'block';
    } else {
        // 👇️ this HIDES the form
        form.style.display = 'none';
    }
});