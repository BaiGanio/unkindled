// ----- THEME SELECTOR ------ //
const themeToggle = document.getElementById('theme-toggle');

themeToggle.addEventListener('click', () => {
    const html = document.documentElement;
    const isDark = html.getAttribute('data-bs-theme') === 'dark';
    
    // Toggle the attribute
    html.setAttribute('data-bs-theme', isDark ? 'light' : 'dark');
    
    // Update button text
    themeToggle.innerText = isDark ? "DARK" : "LIGHT";
});
// ----- THEME SELECTOR ------ //
