extent: aPoint
	"constrain the extent to be a multiple of the protoTile size during resizing"

	(bounds extent // protoTile extent) = (aPoint // protoTile extent)
		ifFalse:
			[self changed.
			bounds _ bounds topLeft extent: (aPoint truncateTo: protoTile extent).
			self layoutChanged.
			self changed]