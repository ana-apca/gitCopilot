# My Node.js Project

This project is a simple web application built using Node.js, Express, Pug, and TypeScript. It serves as a demonstration of how to set up a basic web server with a templating engine and TypeScript support.

## Project Structure

```
my-nodejs-project
├── src
│   ├── controllers
│   │   └── index.ts         # Contains the IndexController for handling requests
│   ├── routes
│   │   └── index.ts         # Defines the application routes
│   ├── views
│   │   └── index.pug        # Pug template for the index view
│   ├── app.ts               # Entry point of the application
│   └── types
│       └── index.ts         # Type definitions for request and response
├── package.json              # npm configuration file
├── tsconfig.json             # TypeScript configuration file
└── README.md                 # Project documentation
```

## Installation

To install the necessary dependencies, run the following command:

```
npm install
```

## Running the Application

To start the application, use the following command:

```
npm start
```

The application will be available at `http://localhost:3000`.

## License

This project is licensed under the MIT License.