drawWideEdge: edge from: leftX
	"Draw the given edge starting from leftX with the edge's fill.
	Return the end value of the drawing operation."
	| rightX fill type lineWidth |
	self inline: false. "Not for the moment"
	type _ self edgeTypeOf: edge.
	dispatchedValue _ edge.
	self dispatchOn: type in: WideLineWidthTable.
	lineWidth _ dispatchReturnValue.
	self dispatchOn: type in: WideLineFillTable.
	fill _ self makeUnsignedFrom: dispatchReturnValue.
	fill = 0 ifTrue:[^leftX].
	"Check if this line is only partially visible"
	"self assert:(self isFillColor: fill)."
	rightX _ leftX + lineWidth.
	self fillSpan: fill from: leftX to: rightX.
	^rightX