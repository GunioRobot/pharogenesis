placeEmbeddedObject: anchoredMorph
	"Place the anchoredMorph or return false if it cannot be placed.
	In any event, advance destX by its width."
	| w |
	"Workaround: The following should really use #textAnchorType"
	anchoredMorph relativeTextAnchorPosition ifNotNil:[^true].
	destX _ destX + (w _ anchoredMorph width).
	(destX > rightMargin and: [(leftMargin + w) <= rightMargin])
		ifTrue: ["Won't fit, but would on next line"
				^ false].
	lastIndex _ lastIndex + 1.
	self setFont.  "Force recalculation of emphasis for next run"
	^ true