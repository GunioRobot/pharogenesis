potentialEmbeddingTargets
	"Return the potential targets for embedding the receiver"

	| oneUp topRend |
	(oneUp _ (topRend _ self topRendererOrSelf) owner) ifNil:[^#()].
	^ (oneUp morphsAt: topRend referencePosition behind: topRend unlocked: true) select:
		[:m | m  isFlexMorph not]