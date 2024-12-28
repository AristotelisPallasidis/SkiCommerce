// ----------------------------------------------
// This is Tutorial File demo.ts
// ----------------------------------------------

let message = 'hello';
let isComplete = false;

type Todo = {
    id: number;
    title: string;
    completed: boolean;
};

let todos: Todo[] = [];

function addTodo(title: string): Todo {

    const newTodo: Todo = {
        id: todos.length + 1,
        title,
        completed: false,
    };

    todos.push(newTodo);

    return newTodo;
}

function toggleTodo(id : number): void {
    const todo = todos.find(todo => todo.id === id);
    if (todo) {
        todo.completed = !todo?.completed;
    }
}

addTodo('Learn TypeScript');
addTodo('Learn MSSQL');
toggleTodo(2);

// Display Todos list
console.log(todos);