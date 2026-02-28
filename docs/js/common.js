// ----- CLICK AUDIO OBJECT ------ //
const clickSound = new Audio('./sounds/click1.mp3'); 
clickSound.volume = 0.5; // Keep it subtle

// 2. Select all navigation links
const navLinks = document.querySelectorAll('.nav-link, .ds-button, .enter-link');

// 3. Attach the sound to each one
navLinks.forEach(link => {
    link.addEventListener('click', (e) => {
        // Reset sound if clicked rapidly
        clickSound.currentTime = 0; 
        clickSound.play();
        
        // If it's a page link, you might need a tiny delay 
        // to let the sound play before the page changes
        if (link.tagName === 'A' && link.getAttribute('href') !== '#') {
            e.preventDefault(); // Stop immediate navigation
            const targetUrl = link.href;
            setTimeout(() => {
                window.location.href = targetUrl;
            }, 150); // 150ms delay is enough for the "click" feel
        }
    });
});
// ----- CLICK AUDIO OBJECT ------ //