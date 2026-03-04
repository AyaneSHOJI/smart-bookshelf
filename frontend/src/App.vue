<script setup lang="ts">
import axios from "axios";
import { ref } from "vue";

interface BookDto {
  id: number;
  title: string;
  author: string;
}

const books = ref<BookDto[]>([]);

async function loadBooks() {
  const res = await axios.get<BookDto[]>("https://localhost:7094/api/books/");
  books.value = res.data;
}
</script>

<template>
  <button @click="loadBooks">Load books</button>

  <div v-for="book in books" :key="book.id">
    <p>{{ book.title }}</p>
    <p>{{ book.author }}</p>
    <br />
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
