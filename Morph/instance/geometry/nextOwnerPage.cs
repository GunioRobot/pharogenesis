nextOwnerPage
	"Tell my container to advance to the next page"
	| targ |
	targ _ owner.
	[targ respondsTo: #nextPage] whileFalse: [targ _ targ owner].
	targ nextPage