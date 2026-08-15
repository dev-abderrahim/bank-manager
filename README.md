# Bank Manager

## Todo

-[ ] Implement Persistent Memory (Database)
-[x] Design the Database scheme
-[x] Implement Interfaces for Users, Accounts, and Transactions
-[ ] Accounts Manager
-[ ] Users Manager
-[ ] Transactions Manager
-[ ] Declare Account types: Regular, Saving... etc.
-[ ] Document classes

## Database:

```text
    Legends:
   ───────────────
    # Primary Key
    @ Foreign Key
    ? Nullable

┌───────────────────────┐          ┌─────────────────────┐          ┌───────────────────────┐
│         User          │          │       Account       │          │      Transaction      │
├────────────────┬──────┤1         ├─────────────┬───────┤1         ├───────────────┬───────┤
│# id            │int   │◄────┐    │# id         │int    │◄─────┐   │# id           │int    │
│  firstname     │string│     │    │  name       │string │      │   │  created_at   │date   │
│  lastname      │string│     │   *│  balance    │decimal│      │  *│  amount       │decimal│
│  email         │string│     └────┤@ owner_id   │int    │      ├───┤@ from_account │int?   │
│  password_hash │string│          │  created_at │date   │      └───┤@ to_account   │int?   │
│  created_at    │date  │          └─────────────┴───────┘          └───────────────┴───────┘
│  updated_at    │date  │
└────────────────┴──────┘
```

## Structure:

```text
                ┌─────────────────────┐
                │ Presentation Layer  │◄────Display the UI, and recieve
                └─────────────┬───────┘          input from user
                        ▲     │
 Return the result of   │     │  Request an operation with
   the specified op     │     │        necessary infos
                        │     ▼
                ┌───────┴─────────────┐
                │    Business Layer   │◄────Process the request and
                └─────────────┬───────┘        validate the input
                        ▲     │
Return the requested    │     │  Request an operation to modify,
         infos          │     │     or read the repository
                        │     ▼
                ┌───────┴─────────────┐
                │      Data Layer     │◄────Connect to repo (DB, In-Memory...)
                └─────────────────────┘              and fetch or modify
```
