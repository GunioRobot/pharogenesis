nextOwnerPage
	"Tell my container to advance to the next page"
	| targ |
	targ _ self ownerThatIsA: BookMorph.
	targ ifNotNil: [targ nextPage]