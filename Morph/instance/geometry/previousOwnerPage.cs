previousOwnerPage
	"Tell my container to advance to the previous page"
	| targ |
	targ _ self ownerThatIsA: BookMorph.
	targ ifNotNil: [targ previousPage]