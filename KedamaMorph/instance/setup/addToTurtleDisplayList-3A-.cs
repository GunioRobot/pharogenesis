addToTurtleDisplayList: p

	| a |
	(p isKindOf: KedamaExamplerPlayer) ifFalse: [^ self].
	a _ turtlesToDisplay copyWithout: p.
	turtlesToDisplay _ a copyWith: p.
