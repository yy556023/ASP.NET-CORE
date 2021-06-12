<template>
    <div class="container">
        <h1>
            待辦事項清單
            <router-link to="/Todo/Create" class="btn btn-outline-success btn-md float-right">新增</router-link>
        </h1>

        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>
                        項目名稱
                    </th>
                    <th>
                        是否已完工
                    </th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="todoItem of todoItemList" v-bind:key="todoItem">
                    <td>
                        {{ todoItem.name }}
                    </td>
                    <td>
                        <input class="check-box" disabled="disabled"
                               type="checkbox" v-model="todoItem.isComplete" />
                    </td>
                    <td>
                        <span class="float-right">
                            <router-link :to="{ path: '/Todo/Edit/' + todoItem.todoItemId }" class="btn btn-outline-primary btn-sm">編輯</router-link> | 
                            <router-link :to="{ path: '/Todo/Delete/' + todoItem.todoItemId }" class="btn btn-outline-danger btn-sm">刪除</router-link>
                        </span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "TodoIndex",
        data() {
            return {
                todoItemList: []
            }
        },
        methods: {
            getTodoItemList() {
                axios.get('/api/todoitem')
                    .then((response) => {
                        this.todoItemList = response.data;
                        console.log(response.data);
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getTodoItemList();
        }
    }
</script>