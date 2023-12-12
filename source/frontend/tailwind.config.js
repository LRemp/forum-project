/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {

    extend: {
      colors: {
        coral: "#ef8354",
        gunmetal: "#2d3142",
        silver: "#bfc0c0",
        paynesgray: "#4f5d75"
      }
    },
  },
  plugins: [],
}