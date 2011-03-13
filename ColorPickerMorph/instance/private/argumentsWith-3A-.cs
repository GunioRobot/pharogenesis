argumentsWith: aColor
	"Return an argument array appropriate to this action selector"

	| nArgs |
	nArgs _ selector numArgs.
	nArgs = 1 ifTrue:[^ {aColor}].
	nArgs = 2 ifTrue:[^ {aColor. sourceHand}].
	nArgs = 3 ifTrue:[^ {aColor. argument. sourceHand}].
