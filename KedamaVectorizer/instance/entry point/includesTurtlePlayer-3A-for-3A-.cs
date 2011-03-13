includesTurtlePlayer: aMethodNode for: obj

	| players p |
	players := self getAllPlayersInMethodNode: aMethodNode for: obj.
	players do: [:e |
		p := Compiler evaluate: e name for: obj logged: false.
		(p isKindOf: KedamaExamplerPlayer) ifTrue: [^ true].
	].
	^ false.
