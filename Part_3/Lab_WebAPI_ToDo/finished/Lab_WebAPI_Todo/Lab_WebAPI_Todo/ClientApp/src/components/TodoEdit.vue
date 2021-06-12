<template>
    <div class="container">


        <h1>待辦事項清單 - 修改</h1>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label" for="Name">項目名稱</label>
                        <input class="form-control" type="text" id="Name"
                               v-model="todoItemName" />
                    </div>
                    <div class="form-group form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox"
                                   v-model="todoItemIsComplete" /> 是否已完工
                        </label>
                    </div>
                    <div class="form-group">
                        <input type="button" v-on:click="doOkButtonClick" value="確定" class="btn btn-outline-primary" /> |
                        <router-link to="/Todo/Index" class="btn btn-outline-info">取消</router-link>
                    </div>
                </form>
            </div>
        </div>


    </div>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "TodoEdit",
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
                var dataToServer = {
                    TodoItemId: this.todoItemId,
                    Name: this.todoItemName,
                    IsComplete: this.todoItemIsComplete,
                };


                axios
                .put("/api/todoitem/" + this.todoItemId,
                    JSON.stringify(dataToServer),
                    { headers: { 'Content-Type': 'application/json' } })
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