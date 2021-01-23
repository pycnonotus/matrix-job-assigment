# hero-trainer

 a mock app using angular 11 and .net5

 **live demo** : [hero.antonweb.co.il][1]

## notes

1. There are server-side and client-side validations.

2. All fields for a new hero are required.

3. First trained is the first training a hero **has** been trained by a trainer (heroCrateDate != firstTrainedDate)

4. If hero has not trained yet, no date will show up at the trained cell.

5. For user authentication I use ASP.NET Identity and JWT.

6. For logging the HTTP requests and Exceptions I use a middleware

[1]: https://hero.antonweb.co.il "Live demo"
