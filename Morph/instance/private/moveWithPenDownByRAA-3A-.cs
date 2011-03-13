moveWithPenDownByRAA: delta

	| trailMorph tfm start tfmEnd xStart |

	self flag: #bob.		"temp revert to old version for Alan's demo"

	"If this is a costume for a player with its pen down, draw a line."
	(trailMorph _ self trailMorph) ifNil: [^self].

	tfm _ self owner transformFrom: "trailMorph" self world.
	start _  self referencePosition.
	trailMorph batchPenTrails 
		ifTrue:
			[trailMorph notePenDown: true forPlayer: self player at: (tfm localPointToGlobal: start)] 		ifFalse:
			[xStart _ (tfm localPointToGlobal: start).
			tfmEnd _ tfm localPointToGlobal: start + delta.
			trailMorph drawPenTrailFor: self from: xStart to: tfmEnd.

			"I don't think we should be doing this if batchPenTrails is false"
			"trailMorph noteNewLocation: tfmEnd forPlayer: self player."]
	