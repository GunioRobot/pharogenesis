checkSourceOverlap
	| t |
	"check for possible overlap of source and destination"
	(sourceForm = destForm and: [dy >= sy]) ifTrue:
		[dy > sy ifTrue:
			["have to start at bottom"
			vDir _ -1.
			sy _ sy + bbH - 1.
			dy _ dy + bbH - 1]
		ifFalse:
			[dx > sx ifTrue:
				["y's are equal, but x's are backward"
				hDir _ -1.
				sx _ sx + bbW - 1.
				"start at right"
				dx _ dx + bbW - 1.
				"and fix up masks"
				nWords > 1 ifTrue: 
					[t _ mask1.
					mask1 _ mask2.
					mask2 _ t]]].
		"Dest inits may be affected by this change"
		destIndex _ (destBits + 4) + (dy * destRaster + (dx // pixPerWord) *4).
		destDelta _ 4 * ((destRaster * vDir) - (nWords * hDir))]