<template>
    <div class="container">


        <h1>待辦事項清單 - 刪除</h1>

        <hr />
        <div>
            <dl class="row">
                <dt class="col-sm-2">
                    項目名稱
                </dt>
                <dd class="col-sm-10">
                    {{ todoItemName }}
                </dd>
                <dt class="col-sm-2">
                    是否已完工
                </dt>
                <dd class="col-sm-10">
                    <input class="check-box" disabled="disabled"
                           type="checkbox" v-model="todoItemIsComplete" />
                </dd>
            </dl>

            <hr>
            <h3>確定要刪除這筆資料嗎?</h3>

            <form >
                <input type="button" v-on:click="doOkButtonClick" value="確定" class="btn btn-outline-danger" /> |
                <router-link to="/Todo/Index" class="btn btn-outline-info">取消</router-link>
            </form>
        </div>



    </div>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "TodoDelete",
        data() {
            return {
                todoItemId: 0,
                todoItemName: "",
                todoItemIsComplete: false
            }
        },
        methods: {
            getTodoItem() {
                axios.get('/api/todoitem/' + this.$route.params.id)
                    .then((response) => {
                        this.todoItemId = response.data.todoItemId;
                        this.todoItemName = response.data.name;
                        this.todoItemIsComplete = response.data.isComplete;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            doOkButtonClick() {
                axios
                .delete("/api/todoitem/" + this.todoItemId )
                .then((response) => {
                    this.$router.replace('/Todo/Index');
                    console.log(response);
                })
            }
        },
        mounted() {
            this.getTodoItem();
        }
    }
</script>