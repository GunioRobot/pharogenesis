openFully
	"Make an educated guess at how wide or tall we are to be, and open to that thickness"

	| thickness amt |
	thickness _ referent boundingBoxOfSubmorphs extent max: (100 @ 100).
	self applyThickness: (amt _ self orientation == #horizontal
			ifTrue:
				[thickness y]
			ifFalse:
				[thickness x]).
	self lastReferentThickness: amt.
	self showFlap