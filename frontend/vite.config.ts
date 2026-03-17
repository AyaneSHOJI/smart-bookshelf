import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import path from "path";

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy: {
      // Proxy API requests to the backend to avoid CORS and TLS issues during dev
      "/api": {
        target: "https://localhost:7094",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
