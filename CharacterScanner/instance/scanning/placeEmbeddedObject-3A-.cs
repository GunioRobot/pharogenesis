placeEmbeddedObject: anchoredMorph
	"Place the anchoredMorph or return false if it cannot be placed.
	In any event, advance destX by its width."

	destX _ destX + (width _ anchoredMorph width).
	(destX > rightMargin and: [(leftMargin + width) <= rightMargin])
		ifTrue: ["Won't fit, but would on next line"
				^ false].
	runStopIndex _ lastIndex.  "Force new calc of emphasis"
	lastIndex _ lastIndex + 1.
	^ true