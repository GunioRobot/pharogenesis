remapFills
	"Replace the fill style dictionary with an array"
	| indexMap newFillStyles index |
	(fillStyles isKindOf: Dictionary) ifFalse:[^false].
	indexMap _ Dictionary new.
	indexMap at: 0 put: 0. "Map zero to zero"
	newFillStyles _ Array new: fillStyles size.
	index _ 1.
	fillStyles associationsDo:[:assoc|
		indexMap at: assoc key put: index.
		newFillStyles at: index put: assoc value.
		index _ index + 1.
	].
	leftFills _ leftFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	rightFills _ rightFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	lineFills _ lineFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	fillStyles _ newFillStyles