<script setup lang="ts">
import type { BookDTO } from "../types/Book";
import { useBookStore } from "../stores/bookstore";

const props = defineProps<{
  book: BookDTO;
}>();

</script>

<template>
<router-link :to="`/books/${props.book.id}`" >
  <li>
    {{ props.book.title }}
  </li>
</router-link>
</template>