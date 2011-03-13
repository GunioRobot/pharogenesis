extent: newExtent
	"Change my scale to fit myself into the given extent.
	Avoid extents where X or Y is zero."
	(newExtent y = 0 or: [ newExtent x = 0 ]) ifTrue: [ ^self ].
	self extent = newExtent ifTrue:[^self].
	scalePoint := newExtent asFloatPoint / (originalForm extent max: 1@1).
	self layoutChanged.
