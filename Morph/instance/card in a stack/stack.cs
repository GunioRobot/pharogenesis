stack
	"Answer the nearest containing Stack, or, if none, a stack in the current project, and if still none, nil.  The extra messiness is because uninstalled backgrounds don't have an owner pointers to their stack."

	| aStack bkgnd |
	bkgnd _ self orOwnerSuchThat: [:oo | oo hasProperty: #myStack].
	bkgnd ifNotNil: [^ bkgnd valueOfProperty: #myStack].

	"fallbacks"
	(aStack _ self ownerThatIsA: StackMorph) ifNotNil: [^ aStack].
	^ Project current currentStack