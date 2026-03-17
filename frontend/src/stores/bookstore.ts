import { defineStore } from "pinia"
import type { BookDTO } from "../types/Book"
import axios from "axios"
import { ref } from "vue";
export const useBookStore = defineStore("book", () => {
  const books = ref<BookDTO[]>([])

  async function fetchBooks() {
    const response = await axios.get<BookDTO[]>("/api/books")
    books.value = response.data
  }

  function addBook(book: BookDTO) {
    books.value.push(book)
  }

  function removeBook(id: number) {
    books.value = books.value.filter(b => b.id !== id)
  }

  return { books, fetchBooks, addBook, removeBook }
})