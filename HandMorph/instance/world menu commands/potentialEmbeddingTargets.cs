potentialEmbeddingTargets
	"Answer a list of targets into which the hand's arguement could be embedded"

	| possibleTargets |
	possibleTargets _ self world morphsAt: menuTargetOffset.
	argument ifNotNil:
		[possibleTargets removeAllFoundIn: argument allMorphs].
	^ possibleTargets