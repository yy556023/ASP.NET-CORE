import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";
import TodoIndex from "@/components/TodoIndex.vue"
import TodoCreate from "@/components/TodoCreate.vue"
import TodoEdit from "@/components/TodoEdit.vue"
import TodoDelete from "@/components/TodoDelete.vue"

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData
    },
    {
        path: "/Todo/Index",
        name: "TodoIndex",
        component: TodoIndex
    },
    {
        path: "/Todo/Create",
        name: "TodoCreate",
        component: TodoCreate
    },
    {
        path: "/Todo/Edit/:id?",
        name: "TodoEdit",
        component: TodoEdit
    },
    {
        path: "/Todo/Delete/:id?",
        name: "TodoDelete",
        component: TodoDelete
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;