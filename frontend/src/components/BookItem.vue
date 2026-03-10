<script setup lang="ts">
import type { BookDto } from "types/Book";

defineProps<{
  book: Book;
}>();
</script>

<template>
  <li>
    {{ book.title }}
    {{ book.author }}
  </li>
</template>
