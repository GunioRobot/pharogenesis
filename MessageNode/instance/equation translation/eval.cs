eval
	"When everything in me is a constant, I can produce a value.  This is only used by the Scripting system (TilePadMorph tilesFrom:in:)"

	| rec args |
	(receiver isKindOf: VariableNode) ifFalse: [^ #illegal].
	rec _ receiver key value.
	args _ arguments collect: [:each | each eval].
	^ rec perform: selector key withArguments: args