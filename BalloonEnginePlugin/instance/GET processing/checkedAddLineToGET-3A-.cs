checkedAddLineToGET: line
	"Add the line to the global edge table if it intersects the clipping region"
	| lineWidth |
	self inline: true.

	(self isWide: line) 
		ifTrue:[lineWidth _ (self wideLineExtentOf: line)]
		ifFalse:[lineWidth _ 0].
	(self lineEndYOf: line) + lineWidth < (self fillMinYGet) ifTrue:[^0].
	"Overlaps in Y but may still be entirely right of clip region"
	((self edgeXValueOf: line) - lineWidth >= self fillMaxXGet and:[
		(self lineEndXOf: line) - lineWidth >= self fillMaxXGet]) ifTrue:[^0].
	self addEdgeToGET: line.
