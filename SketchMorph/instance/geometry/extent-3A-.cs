extent: newExtent
	"Change my scale to fit myself into the given extent."
	self extent = newExtent ifTrue:[^self].
	scalePoint _ newExtent asFloatPoint / originalForm extent.
	self layoutChanged.
