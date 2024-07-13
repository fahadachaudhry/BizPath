# BizPath

An application that takes businesses through various workflows during a lead generation process.

### The application runs on a simple yet powerful and highly scalable Bahavioural pattern (aka Strategy or Polymorphic Service pattern).

#### The application consists of 3 different projects (or services)

1. BizPath: The main project that contains the api and controller logic.
2. Commong: Containing info like DTOs, Interfaces, Custom Excaptions and Exception Lookups.
3. RuleEngine: This is where the magic happens.

# Assumptions

Not many, just one!

Following the following path: BizPath -> Controllers -> BusinessController -> ln 31

The app assumes that the "industry" is the starting point and a deciding factor for the Workflow Engine's Polymorphic Strategy (Bahavioural Pattern)
Therefore, It is kept as a mandatory form/data field for a workflow to successfully trigger.


_PS: This app is by no means perfect, but I hope this gives you a good idea of how I think and code._