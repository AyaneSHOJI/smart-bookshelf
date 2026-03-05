<script setup lang="ts">
import axios from "axios";
import type { EnumMember } from "typescript";
import { ref } from "vue";
import { computed } from "vue";

interface BookDto {
  id: number;
  title: string;
  author: string;
  type: EnumMember;
  category: EnumMember;
  IsLent: boolean;
  ToWhomLent: string;
}

interface BookForm {
  title: string;
  author: string;
}

const books = ref<BookDto[]>([]);

async function loadBooks() {
  const res = await axios.get<BookDto[]>("https://localhost:7094/api/books/");
  books.value = res.data;
}

const form = ref<BookForm>({
  title: "",
  author: "",
});

const title = ref("");

function submit() {
  const newBook: BookDto = {
    id: books.value.length + 1,
    title: form.value.title,
    author: form.value.author,
    type: undefined as any,
    category: undefined as any,
    IsLent: false,
    ToWhomLent: "",
  };
  books.value.push(newBook);
  form.value.title = "";
  form.value.author = "";
}

const keyword = ref("");

const filteredBooks = computed(() => {
  return books.value.filter((book) =>
    book.title.toLocaleLowerCase().includes(keyword.value.toLocaleLowerCase()),
  );
});

const sortedBooks = computed(() =>{
  return [...filteredBooks.value].sort((a,b) =>
  a.title.localeCompare(b.title))
}
)
</script>

<template>
  <div class="container">
    <div class="left-section">
      <button @click="loadBooks">Load books</button>

      <div v-for="book in books" :key="book.id">
        <div>
          <p>{{ book.title }}</p>
          <p>{{ book.author }}</p>
          <br />
        </div>
      </div>

      <input v-model="keyword" placeholder="Research" />
      <li v-if="sortedBooks" v-for="book in sortedBooks" :key="book.id">
        {{ book.title }}
      </li>
    </div>

    <div class="right-section">
      <input v-model="form.title" placeholder="Title" />
      <input v-model="form.author" placeholder="Author" />
      <p>{{ title }}</p>
      <button v-on:click="submit">Submit</button>
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
