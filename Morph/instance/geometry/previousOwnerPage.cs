previousOwnerPage
	"Tell my container to advance to the previous page"
	| targ |
	targ _ owner.
	[targ respondsTo: #previousPage] whileFalse: [targ _ targ owner].
	targ previousPage