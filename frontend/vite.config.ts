import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy: {
      // Proxy API requests to the backend to avoid CORS and TLS issues during dev
      '/api': {
        target: 'http://localhost:5278',
        changeOrigin: true,
        secure: false,
      },
    },
  },
})
