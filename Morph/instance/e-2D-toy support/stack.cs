stack
	"Answer the nearest containing Stack, or, if none, a stack in the current project, and if still none, nil.  The extra messines is because uninstalled backgrounds won't have backpointers to their stack."

	| aStack |
	(aStack _ self ownerThatIsA: StackMorph) ifNotNil: [^ aStack].
	^ Project current currentStack