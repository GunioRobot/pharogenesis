checkedAddBezierToGET: bezier
	"Add the bezier to the global edge table if it intersects the clipping region"
	| lineWidth |
	self inline: true.

	(self isWide: bezier) 
		ifTrue:[lineWidth _ (self wideBezierExtentOf: bezier)]
		ifFalse:[lineWidth _ 0].
	(self bezierEndYOf: bezier) + lineWidth < (self fillMinYGet) ifTrue:[^0].
	"Overlaps in Y but may still be entirely right of clip region"
	((self edgeXValueOf: bezier) - lineWidth >= self fillMaxXGet and:[
		(self bezierEndXOf: bezier) - lineWidth >= self fillMaxXGet]) ifTrue:[^0].
	self addEdgeToGET: bezier.
