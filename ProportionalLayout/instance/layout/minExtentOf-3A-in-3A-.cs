minExtentOf: aMorph in: newBounds
	"Return the minimal size aMorph's children would require given the new bounds"
	| min extent frame |
	min _ 0@0.
	aMorph submorphsDo:[:m|
		"Map the minimal size of the child through the layout frame.
		Note: This is done here and not in the child because its specific
		for proportional layouts. Perhaps we'll generalize this for table
		layouts but I'm not sure how and when."
		extent _ m minExtent.
		frame _ m layoutFrame.
		frame ifNotNil:[extent _ frame minExtentFrom: extent].
		min _ min max: extent].
	^min