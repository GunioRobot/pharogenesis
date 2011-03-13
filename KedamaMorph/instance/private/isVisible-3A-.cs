isVisible: examplerPlayer

	| turtleMorph |
	turtleMorph _ examplerPlayer costume.
	turtleMorph visible ifFalse: [^ false].
	turtleMorph owner isRenderer ifFalse: [^ true].
	^ turtleMorph owner visible.
