fullDraw: aMorph

	self comment: 'level: ' with: morphLevel.
	morphLevel _ morphLevel+1.
	self preserveStateDuring:
		[:inner | inner setupGStateForMorph: aMorph.
		aMorph fullDrawPostscriptOn: inner].
	morphLevel _ morphLevel-1.
	self comment: 'end morph: ' with: aMorph.
	self comment: 'level: ' with: morphLevel.	