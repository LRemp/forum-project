# forum-project
T120B165 Saityno taikomųjų programų projektavimas modulio projektas

# Sprendžiamo uždavinio aprašymas

Projekto tikslas – sukurti platformą leidžiančią vartotojams laisvai bendrauti, kurti pokalbius pagal aktualias temas.

Veikimo principas – projekto programą sudaro dvi dalys: kliento pusė ir serverio pusė.

Vartotojas norėdamas dalyvauti pokalbiuose pasirenka atitinkamą kategoriją. Kategorijoje gali prisijungti prie pokalbio(angl. Thread) arba sukurti naują. Administratorius gali kurti naujas kategorijas, šalinti ir blokuoti vartotojus.

## Funkciniai reikalavimai
### Neregistruotas naudotojas
1.      Peržiūrėti platformos reprezentacinį puslapį;
2.      Peržiūrėti prisijungimo puslapį;
3.      Peržiūrėti registracijos puslapį;
4.  	Užsiregistruoti į sistemą;
5.      Prisijungti prie sistemos;
6.      Peržiūrėti kategorijas;
7.      Peržiūrėti pokalbius;
8.      Peržiūrėti pokalbių žinutes;'

### Registruotas sistemos naudotojas
1.      Atsijungti interetinės aplikacijos;
2.      Peržiūrėti kategorijas;
3.      Kurti, ištrinti, redaguoti pokalbius;
4.      Kurti, ištrinti, redaguoti žinutes;
5.      Redaguoti savo profilį;

### Administratorius
1.      Kurti, ištrinti, redaguoti kategorijas;
2.      Blokuoti vartotojus;
3.      Šalinti vartotojus;

## Sistemos sudedamosios dalys:

-   Kliento pusė, vartotojo sąsaja (ang. Front-End) – naudojant React.js, Float UI;
-   Serverio pusė, API, JWT (angl. Back-End) – naudojant ASP.NET, Dapper, MySQL duomenų bazę.

# API endpoints

## Channels

### GET channels/list

Returns a collection of channels

### Resource URL
`https://chathub.com/api/channels`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
None

### Example Response

```
[
    {
        "name": "New request",
        "description": "This is a channel to test it out"
    }
]
```

### GET channel

Returns a object of channel

### Resource URL
`https://chathub.com/api/channels/{channelId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |

### Example Response

```
{
    "name": "New request",
    "description": "This is a channel to test it out"
}
```

### POST channel

Creates a request for channel creation which required administrators approval

### Resource URL
`https://chathub.com/api/channels`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes    |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| name | Yes | Name of the channel | | New channel |
| description | Yes | Description of the channel | | Channel description |

### Example Response

```
13
```

### DELETE channel

Deletes a channel

### Resource URL
`https://chathub.com/api/channels/{channelId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes    |
| Requires administrator authorization? | Yes |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |

### Example Response

```
HTTP 
```

## Channel requests

### GET requests/list

Returns a collection of requests for channel creation

### Resource URL
`https://chathub.com/api/channels/requests`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |
| Requires administrator authorization? | Yes |

### Parameters
None

### Example Response

```
[
    {
        "id": 23,
        "name": "New request",
        "description": "This is a channel to test it out"
    }
]
```
### POST requests/list

Approves the request, removes the request and creates the channel based on the request

### Resource URL
`https://chathub.com/api/channels/requests/{requestId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |
| Requires administrator authorization? | Yes |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| requestId | Yes | Specifies wanted request | | 13 |

### Example Response

```

```

## Conversations

### GET conversations/list

Returns a collection of conversations from the specified channel

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |

### Example Response

```
[
    {
        "name": "Postman testing",
        "description": "Running postman tests",
        "author": null,
        "channel": {
            "name": "New request",
            "description": "This is a channel to test it out"
        }
    }
]
```

### GET conversation

Returns a object of conversation

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |

### Example Response

```
{
    "name": "Postman testing",
    "description": "Running postman tests",
    "author": null,
    "channel": {
        "name": "New request",
        "description": "This is a channel to test it out"
    }
}
```

### POST conversation

Creates conversation in the specified channel

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |
| name | Yes | Name of the conversation | | New conversation |
| description | Yes | Description of the conversation | | Conversation Description |

### Example Response

```

```

### DELETE conversation

Deletes the specified conversation

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |
| Requires administrator authorization? | Yes |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |

### Example Response

```

```

## Messages

### GET messages/list

Returns a collection of messages from the specified conversation

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}/messages`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |

### Example Response

```
[
    {
        "text": "Hi there",
        "created": "2023-11-29T11:50:45",
        "author": null,
        "conversation": {
            "name": "Postman testing",
            "description": "Running postman tests",
            "author": null,
            "channel": null
        }
    }
]
```

### GET message

Returns a object of message

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}/messages/{messageId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | No     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |
| messageId | Yes | Specifies wanted message | | 1 |

### Example Response

```
{
    "text": "Hi there",
    "created": "2023-11-29T11:50:45",
    "author": null,
    "conversation": {
        "name": "Postman testing",
        "description": "Running postman tests",
        "author": null,
        "channel": null
    }
}
```

### POST message

Creates conversation in the specified channel

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}/messages`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |
| text | Yes | Text of the message | | New message |

### Example Response

```

```

### DELETE message

Deletes the specified message

### Resource URL
`https://chathub.com/api/channels/{channelId}/conversations/{conversationId}/messages/{messageId}`

### Resource information
|                          |        |
|---                       |---     |
| Response format          | JSON   | 
| Requires authentication? | Yes     |

### Parameters
| Name | Required | Description | Default Value | Example |
|------|----------|-------------|--------------|---------|
| channelId | Yes | Specifies wanted channel | | 13 |
| conversationId | Yes | Specifies wanted conversation | | 10 |
| messageId | Yes | Specifies wanted message | | 1 |

### Example Response

```

```