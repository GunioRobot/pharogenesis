moveWithPenDownBy: delta

	| trailMorph tfm start tfmEnd |
	"If this is a costume for a player with its pen down, draw a line."
	(trailMorph _ self trailMorph) ifNotNil:
		[tfm _ self owner transformFrom: trailMorph.
		start _  self referencePosition.
		Preferences batchPenTrails
			ifTrue: [trailMorph notePenDown: true
								forPlayer: self player
								at: (tfm localPointToGlobal: start)]
			ifFalse: [trailMorph drawPenTrailFor: self
								from: (tfm localPointToGlobal: start)
								to: (tfmEnd _ tfm localPointToGlobal: start + delta).
					trailMorph noteNewLocation: tfmEnd forPlayer: self player]]
