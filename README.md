# Gallery

**Gallery** is a web API, implemented using .NET 8 and ASP.NET Core. It's been designed for users to store images within albums and manage them.

## Remarks

### appsettings

- Should set valid **ConnectionStrings**
- Should set valid **SmtpSettings**

```json
"ConnectionStrings": {
    "GalleryConnection": "Server=localhost;UserID=userId;Password=password;Port=3306;Database=Gallery"
  },
  "SmtpSettings": {
    "Server": "smtp.ethereal.email",
    "Port": 587,
    "From": "maynard.roberts@ethereal.email",
    "Password": "M3hAxJSYtu4GBjPdux"
  }
```