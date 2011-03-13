includesTurtlePlayer: aMethodNode for: obj

	| players p |
	players _ self getAllPlayersInMethodNode: aMethodNode for: obj.
	players do: [:e |
		p _ Compiler evaluate: e name for: obj logged: false.
		(p isKindOf: KedamaExamplerPlayer) ifTrue: [^ true].
	].
	^ false.
