Feature: Iniciar Sesión
  Como usuario registrado
  Quiero poder iniciar sesión en el sistema
  Para acceder a mis datos personales

  Scenario: Inicio de sesión exitoso
    Given existe un usuario con email "usuario1@example.com" y contraseña "Password1"
    When el usuario intenta iniciar sesión con email "usuario1@example.com" y contraseña "Password1"
    Then el inicio de sesión debería ser con exitoso

  Scenario: Inicio de sesión fallido por contraseña incorrecta
    Given existe un usuario con email "usuario1@example.com" y contraseña "Password1"
    When el usuario ingresa el email "usuario1@example.com" y una contraseña incorrecta "PasswordIncorrecta"
    Then el inicio de sesión debería ser sin exitoso

  Scenario: Inicio de sesión fallido por usuario no registrado
    Given no existe un usuario con email "usuarioNoExiste@example.com"
    When el usuario intenta iniciar sesión con el email inexistente "usuarioNoExiste@example.com" y la contraseña "Password123"
    Then el inicio de sesión debería fallar por usuario inexistente
