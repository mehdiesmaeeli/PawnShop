export default defineNuxtConfig({
    devtools: { enabled: true },
    css: ['~/assets/css/tailwind.css'],
    postcss: {
        plugins: {
            tailwindcss: {},
            autoprefixer: {},
        },
    },
    modules: ['@nuxtjs/tailwindcss'],
})