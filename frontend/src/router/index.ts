import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";
import BookDetail from "../views/BookDetail.vue";

const routes = [
  {
    path: "/",
    component: Home,
  },
  {
    path: "/books/:id",
    component: BookDetail,
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
