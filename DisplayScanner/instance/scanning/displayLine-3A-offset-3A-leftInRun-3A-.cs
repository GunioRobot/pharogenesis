displayLine: textLine offset: offset leftInRun: leftInRun
	"The call on the primitive (scanCharactersFrom:to:in:rightX:) will be interrupted according to an array of stop conditions passed to the scanner at which time the code to handle the stop condition is run and the call on the primitive continued until a stop condition returns true (which means the line has terminated).  leftInRun is the # of characters left to scan in the current run; when 0, it is time to call setStopConditions."
	| done stopCondition nowLeftInRun |
	line _ textLine.
	morphicOffset _ offset.
	leftMargin _ (line leftMarginForAlignment: textStyle alignment) + offset x.
	runX _ destX _ leftMargin.
	rightMargin _ line rightMargin + offset x.
	lineY _ line top + offset y.
	lineHeight _ line lineHeight.
	fillBlt == nil ifFalse:
		["Not right"
		fillBlt destX: line left destY: lineY
			width: leftMargin - line left height: lineHeight; copyBits].
	lastIndex _ line first.
	leftInRun <= 0
		ifTrue: [self setStopConditions.  "also sets the font"
				nowLeftInRun _ text runLengthFor: lastIndex]
		ifFalse: [nowLeftInRun _ leftInRun].
	destY _ lineY + line baseline - font ascent.
	runStopIndex _ lastIndex + (nowLeftInRun - 1) min: line last.
	spaceCount _ 0.
	done _ false.
	[done] whileFalse: 
		[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
						in: text string rightX: rightMargin stopConditions: stopConditions
						kern: kern displaying: true.
		"see setStopConditions for stopping conditions for displaying."
		done _ self perform: stopCondition].
	fillBlt == nil ifFalse:
		[fillBlt destX: destX destY: lineY width: line right-destX height: lineHeight;
				copyBits].
	^ runStopIndex - lastIndex   "Number of characters remaining in the current run"