searchForNewTopEdgeFrom: leftEdge at: yValue
	"Find the next top edge in the AET. 
	Note: We have to make sure that intersection edges are returned appropriately."
	| edge topFace |
	topFace _ fillList first.
	topFace == nil ifTrue:[^aet next]. "Next edge must be top"
	[aet atEnd] whileFalse:[
		"Check if we have an intersection first."
		nextIntersection xValue <= aet peek xValue ifTrue:[^nextIntersection].
		edge _ aet next.
		"Check if the edge is on top"
		(self isOnTop: edge at: yValue) ifTrue:[^edge].
		"If the edge is not on top, toggle the (back) fills of it"
		self toggleBackFillsOf: edge at: yValue validate: true.
	].
	^nil