interface Message {
    id: number,
    text: string,
    created: string,
    author: Author
}

interface Author {
    username: string,
    email: string
}