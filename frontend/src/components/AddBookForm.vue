<script setup lang="ts">
import { ref } from "vue";
import type { BookDTO } from "../types/Book";
import { useBookStore } from "../stores/bookstore.ts"

const store = useBookStore;

interface BookForm {
  title: string;
  author: string;
}

const emit = defineEmits<{ (e: "add", book: BookDTO): void }>();

const form = ref<BookForm>({
  title: "",
  author: "",
});

function submit() {
  store
  form.value.title = "";
  form.value.author = "";
}
</script>

<template>
  <input v-model="form.title" placeholder="Title" />
  <input v-model="form.author" placeholder="Author" />
  <button v-on:click="submit">Submit</button>
</template>

<style scoped>
.container {
  display: flex;
  gap: 2rem;
  padding: 2rem;
  min-height: 100vh;
}

.left-section {
  flex: 1;
  border-right: 1px solid #ccc;
  padding-right: 2rem;
}

.right-section {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.left-section button,
.right-section button {
  padding: 0.5rem 1rem;
  background-color: #42b883;
  color: white;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  font-size: 1rem;
}

.left-section button:hover,
.right-section button:hover {
  background-color: #369970;
}

.left-section input,
.right-section input {
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 0.5rem;
  font-size: 1rem;
}

.left-section div {
  margin-top: 1rem;
  padding: 1rem;
  border: 1px solid #eee;
  border-radius: 0.5rem;
}

.left-section p {
  margin: 0.5rem 0;
}

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
