<script setup lang="ts">
import axios from "axios";
import type { EnumMember } from "typescript";
import { ref, computed, onMounted } from "vue";
import type { BookDto } from "./types/Book";
import BookList from "./components/BookList.vue";
import AddBookForm from "./components/AddBookForm.vue";

const books = ref<BookDto[]>([]);

async function loadBooks() {
  const res = await axios.get<BookDto[]>("/api/books/");
  books.value = res.data;
}

onMounted(loadBooks);

function addBook(book: BookDto) {
  const nextId = (books.value.length > 0 ? Math.max(...books.value.map((b) => b.id)) : 0) + 1;
  books.value.push({ ...book, id: nextId });
}

const keyword = ref("");

const filteredBooks = computed(() => {
  return books.value.filter((book) =>
    book.title.toLocaleLowerCase().includes(keyword.value.toLocaleLowerCase()),
  );
});

const sortedBooks = computed(() => {
  return [...filteredBooks.value].sort((a, b) =>
    a.title.localeCompare(b.title),
  );
});
</script>

<template>
  <div class="container">
    <div class="left-section">
      <BookList :books="books" />
    </div>

    <div class="right-section">
      <AddBookForm @add="addBook" />
    </div>
  </div>
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
