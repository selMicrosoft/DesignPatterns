This pattern helps us solve for scaling database systems independently.
We could have all queries go to one cluster of db's and the commands go to a separate cluster,
allowing us to scale our db's as needed. Another idea I like, which Martin Fowler points out
in the article below, is that on top of potentially separating reads/writes from each other, we
could take it one step further and even separate out complex/demanding queries by having them
read from something like a Reporting Database (one not used for typical operations, but for complex
report generation, etc)

I would check out Martin Fowler's explanation of CQRS, though, as it is not intended to solve all
problems and it is typically advised against trying to use CQRS through an entire system.
https://martinfowler.com/bliki/CQRS.html