// --- 1. GLOBAL DEFINITIONS ---
const music = document.getElementById('bg-music');
const btn = document.getElementById('bonfire-btn');

// --- 2. SAVE STATE (Before Leaving) ---
window.addEventListener('beforeunload', () => {
    if (music) {
        localStorage.setItem('ds_music_pos', music.currentTime);
        localStorage.setItem('ds_music_playing', !music.paused);
    }
});

// --- 3. LOAD & RESUME STATE (On Page Load) ---
window.addEventListener('load', () => {
    if (!music) return; // Exit if no audio tag found

    const savedPos = localStorage.getItem('ds_music_pos');
    const wasPlaying = localStorage.getItem('ds_music_playing') === 'true';

    if (savedPos) music.currentTime = parseFloat(savedPos);
    
    if (wasPlaying) {
        // Try to play immediately (works if user already interacted with site)
        music.volume = 0.3;
        music.play().catch(() => {
            console.log("Autoplay blocked. User interaction needed to resume.");
        });
    }
});

// --- 4. BUTTON LOGIC (WITH SAFETY CHECK) ---
// This 'if (btn)' check prevents the 'Uncaught TypeError' on pages without the button
if (btn) {
    btn.addEventListener('click', () => {
        if (music.paused) {
            // Start from 22 seconds if it's the beginning
            if (music.currentTime === 0) {
                music.currentTime = 22;
            }
            
            music.volume = 0;
            music.play();
            
            // Dark Souls style slow volume fade-in
            let vol = 0;
            const fadeIn = setInterval(() => {
                if (vol < 0.3) {
                    vol += 0.01;
                    music.volume = vol;
                } else {
                    clearInterval(fadeIn);
                }
            }, 100);

            btn.innerHTML = '<i class="bi bi-soundwave pulse-icon"></i>';
            btn.style.boxShadow = "0 0 20px #ff4500"; 
            localStorage.setItem('ds_music_playing', 'true');
        } else {
            music.pause();
            btn.innerHTML = '<i class="bi bi-play"></i>';
            btn.style.boxShadow = "none";
            btn.classList.remove('lit');
            localStorage.setItem('ds_music_playing', 'false');
        }
    });
}

// --- 5. INTERACTION RESUME (For Pages Without Button) ---
// If the user clicks ANYWHERE on a page without a button, try to resume music
document.addEventListener('mousedown', () => {
    const wasPlaying = localStorage.getItem('ds_music_playing') === 'true';
    if (wasPlaying && music && music.paused) {
        music.play();
    }
});
