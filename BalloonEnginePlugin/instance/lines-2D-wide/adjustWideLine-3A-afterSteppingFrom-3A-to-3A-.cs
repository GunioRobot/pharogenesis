adjustWideLine: line afterSteppingFrom: lastX to: nextX
	"Adjust the wide line after it has been stepped from lastX to nextX.
	Special adjustments of line width and start position are made here
	to simulate a rectangular brush"
	|  yEntry yExit lineWidth lineOffset deltaX xDir baseWidth |
	self inline: false.	"Don't inline this"


	"Fetch the values the adjustment decisions are based on"
	yEntry _ (self wideLineEntryOf: line).
	yExit _ (self wideLineExitOf: line).
	baseWidth _ self wideLineExtentOf: line.
	lineOffset _ self offsetFromWidth: baseWidth.
	lineWidth _ self wideLineWidthOf: line.
	xDir _ self lineXDirectionOf: line.
	deltaX _ nextX - lastX.

	"Adjust the start of the line to fill an entire rectangle"
	yEntry < baseWidth ifTrue:[
		xDir < 0
			ifTrue:[	lineWidth _ lineWidth - deltaX] "effectively adding"
			ifFalse:[	lineWidth _ lineWidth + deltaX.
					self edgeXValueOf: line put: lastX].
	].

	"Adjust the end of x-major lines"
	((yExit + lineOffset) = 0) ifTrue:[
		xDir > 0
			ifTrue:[lineWidth _ lineWidth - (self lineXIncrementOf: line)]
			ifFalse:[lineWidth _ lineWidth + (self lineXIncrementOf: line).	"effectively subtracting"
					self edgeXValueOf: line put: lastX].
	].

	"Adjust the end of the line to fill an entire rectangle"
	(yExit + lineOffset) > 0 ifTrue:[
		xDir < 0
			ifTrue:[	lineWidth _ lineWidth + deltaX. "effectively subtracting"
					self edgeXValueOf: line put: lastX]
			ifFalse:[	lineWidth _ lineWidth - deltaX]
	].

	"Store the manipulated line width back"
	self wideLineWidthOf: line put: lineWidth.