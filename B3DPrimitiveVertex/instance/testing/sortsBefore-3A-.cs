sortsBefore: pVertex
	"Return true if the receiver should be sorted before the given primitive vertex.
	Support for rasterizer simulation. Only valid if window position has been computed before."
	| y0 y1 |
	y0 _ self windowPosY.
	y1 _ pVertex windowPosY.
	y0 = y1 
		ifTrue:[^self windowPosX <= pVertex windowPosX]
		ifFalse:[^y0 < y1]