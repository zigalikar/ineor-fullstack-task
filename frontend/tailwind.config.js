/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    fontSize: {
      h0: ['37.5rem', '37.5rem']
    },
    spacing: {
      4: '0.25rem',
      8: '0.5rem',
      16: '1rem',
      96: '6rem',
      192: '12rem',
    }
  },
  plugins: [],
}
