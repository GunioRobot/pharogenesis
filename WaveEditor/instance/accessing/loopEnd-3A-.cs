loopEnd: aNumber

	loopEnd _ (aNumber asInteger max: 1) min: graph data size.
	possibleLoopStarts _ nil.
