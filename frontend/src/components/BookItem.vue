<script setup lang="ts">
import type { BookDTO } from "../types/Book";
import { useBookStore } from "../stores/bookstore";

defineProps<{
  book: BookDTO;
}>();
</script>

<template>
  <li>
    {{ book.title }}
  </li>
</template>
