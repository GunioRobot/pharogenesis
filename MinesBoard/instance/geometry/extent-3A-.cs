extent: aPoint
	"constrain the extent to be a multiple of the protoTile size during resizing"
	super extent: (aPoint truncateTo: protoTile extent).