focusMorph: newFocus
	"Set the new focus morph"
	focusMorph ifNotNil:[focusMorph paletteDetached: self]. "In case the morph is interested"
	focusMorph _ newFocus.
	focusMorph ifNotNil:[focusMorph paletteAttached: self]. "In case the morph is interested"