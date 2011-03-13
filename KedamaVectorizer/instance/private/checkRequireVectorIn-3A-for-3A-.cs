checkRequireVectorIn: aMessageNode for: obj

	| players playersSet sel playerNodes |
	"self halt."
	playerNodes _ self getAllPlayersIn: aMessageNode for: obj.
	players _ playerNodes collect: [:e | Compiler evaluate: e name for: obj logged: false.].
	playersSet _ players asSet.
	(playersSet select: [:e | e isPrototypeTurtlePlayer]) size = 0 ifTrue: [
		attributes setAttribute: #firstTurtle of: aMessageNode to: (Compiler evaluate: playerNodes first name for: obj logged: false).
		attributes setAttribute: #requireVector of: aMessageNode to: false.
		^ self.
	].
	(playersSet select: [:e | e isPrototypeTurtlePlayer]) size > 0 ifTrue: [	
		playerNodes with: players do: [:n :p |
			p isPrototypeTurtlePlayer ifTrue: [
				sel _ self getSelectorRootFor: p fromMessageNode: aMessageNode for: obj ignoreSelectors: #(beNotZero: setTurtleCount: getTurtleCount setGrouped: getGrouped).
				sel ifNotNil: [
					(self isVectorizationRequiredWithPlayer: p andSelector: sel) ifTrue: [
						attributes setAttribute: #requireVector of: aMessageNode to: true.
						attributes setAttribute: #firstTurtle of: aMessageNode to: p.
						attributes setAttribute: #firstNode of: aMessageNode to: n.
						^ self.
					].
				].
			].
		].
	].

	attributes setAttribute: #firstTurtle of: aMessageNode to: players first.
	attributes setAttribute: #requireVector of: aMessageNode to: false.
