indicateAllSiblings
	"Indicate all the receiver and all its siblings by flashing momentarily."

	| aPlayer allBoxes |
	(aPlayer _ self topRendererOrSelf player) belongsToUniClass ifFalse: [^ self "error: 'not uniclass'"].
	allBoxes _ aPlayer class allInstances
		select: [:m | m costume world == ActiveWorld]
		thenCollect: [:m | m costume boundsInWorld].

	5 timesRepeat:
		[Display flashAll: allBoxes andWait: 120]