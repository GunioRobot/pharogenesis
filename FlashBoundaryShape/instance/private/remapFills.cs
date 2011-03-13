remapFills
	"Replace the fill style dictionary with an array"
	| indexMap newFillStyles index |
	(fillStyles isKindOf: Dictionary) ifFalse:[^false].
	indexMap := Dictionary new.
	indexMap at: 0 put: 0. "Map zero to zero"
	newFillStyles := Array new: fillStyles size.
	index := 1.
	fillStyles associationsDo:[:assoc|
		indexMap at: assoc key put: index.
		newFillStyles at: index put: assoc value.
		index := index + 1.
	].
	leftFills := leftFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	rightFills := rightFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	lineFills := lineFills valuesCollect:[:value| indexMap at: value ifAbsent:[0]].
	fillStyles := newFillStyles