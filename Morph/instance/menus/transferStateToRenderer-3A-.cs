transferStateToRenderer: aRenderer
	| current |
	"Transfer knownName, actorState, and player info over to aRenderer, which is being imposed above me as a transformation shell"

	(current _ self actorStateOrNil) ifNotNil:
		[aRenderer actorState: current.
		self actorState: nil].

	(current _ self knownName) ifNotNil:
		[aRenderer setNameTo: current.
		self setNameTo: nil].

	(current _ self player) ifNotNil:
		[aRenderer player: current.
		self player rawCostume: aRenderer.
		"self player: nil"]