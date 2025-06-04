export const backendApi = {
  "openapi": "3.0.4",
  "info": {
    "title": "PatasSolidarias.Api",
    "version": "1.0"
  },
  "paths": {
    "/api/Auth/login": {
      "post": {
        "tags": [
          "Auth"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Usuario": {
      "get": {
        "tags": [
          "Usuario"
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "post": {
        "tags": [
          "Usuario"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "put": {
        "tags": [
          "Usuario"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Usuario"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Usuario/{id}": {
      "get": {
        "tags": [
          "Usuario"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Usuario"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "EUsuarioTipo": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "LoginRequest": {
        "type": "object",
        "properties": {
          "email": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Usuario": {
        "required": [
          "descricao",
          "email",
          "nome",
          "senha"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "nome": {
            "type": "string",
            "nullable": true
          },
          "senha": {
            "type": "string",
            "nullable": true
          },
          "criadoDataHora": {
            "type": "string",
            "format": "date-time"
          },
          "usuarioTipoId": {
            "$ref": "#/components/schemas/EUsuarioTipo"
          },
          "descricao": {
            "type": "string",
            "nullable": true
          },
          "usuarioTipo": {
            "$ref": "#/components/schemas/UsuarioTipo"
          }
        },
        "additionalProperties": false
      },
      "UsuarioTipo": {
        "required": [
          "nome"
        ],
        "type": "object",
        "properties": {
          "id": {
            "$ref": "#/components/schemas/EUsuarioTipo"
          },
          "nome": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
