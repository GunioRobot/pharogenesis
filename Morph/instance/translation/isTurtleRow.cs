isTurtleRow

	| aCollection selectorCollection |
	aCollection _ Set new.
	selectorCollection _ Set new.
	self accumlatePlayersInto: aCollection andSelectorsInto: selectorCollection.
	#(turtleCount: turtleCount grouped: grouped) do: [:sel |
		(selectorCollection includes: sel) ifTrue: [^ false].
	].

	aCollection do: [:e |
		(e isKindOf: KedamaExamplerPlayer) ifTrue: [^ true].
	].
	^ false.
