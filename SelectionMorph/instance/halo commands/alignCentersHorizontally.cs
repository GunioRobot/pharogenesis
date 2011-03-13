alignCentersHorizontally
	"Make every morph in the selection have the same vertical center as the topmost item."

	| minLeft leftMost |
	selectedItems size > 1 ifFalse: [^ self].
	minLeft _ (selectedItems collect: [:itm | itm left]) min.
	leftMost _ selectedItems detect: [:m | m left = minLeft].
	selectedItems do:
		[:itm | itm center: (itm center x @ leftMost center y)].

	self changed
