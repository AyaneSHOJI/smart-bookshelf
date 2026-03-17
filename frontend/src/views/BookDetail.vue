<script setup lang="ts">
import { computed } from "vue";
import { useRoute } from "vue-router";
import { useBookStore } from "../stores/bookstore";

const route = useRoute();
const store = useBookStore();

const book = computed(() =>
  store.books.find((b) => b.id === Number(route.params.id)),
);
</script>

<template>
  <div v-if="book">
    <h2>{{ book.title }}</h2>
    <p>{{ book.author }}</p>
  </div>
</template>
