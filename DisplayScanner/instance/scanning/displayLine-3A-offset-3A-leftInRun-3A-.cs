displayLine: textLine offset: offset leftInRun: leftInRun
	"The call on the primitive (scanCharactersFrom:to:in:rightX:) will be interrupted according to an array of stop conditions passed to the scanner at which time the code to handle the stop condition is run and the call on the primitive continued until a stop condition returns true (which means the line has terminated).  leftInRun is the # of characters left to scan in the current run; when 0, it is time to call setStopConditions."
	| done stopCondition nowLeftInRun startIndex string lastPos |
	line _ textLine.
	morphicOffset _ offset.
	lineY _ line top + offset y.
	lineHeight _ line lineHeight.
	rightMargin _ line rightMargin + offset x.
	lastIndex _ line first.
	leftInRun <= 0 ifTrue: [self setStopConditions].
	leftMargin _ (line leftMarginForAlignment: alignment) + offset x.
	destX _ runX _ leftMargin.
	fillBlt == nil ifFalse:
		["Not right"
		fillBlt destX: line left destY: lineY
			width: line width left height: lineHeight; copyBits].
	lastIndex _ line first.
	leftInRun <= 0
		ifTrue: [nowLeftInRun _ text runLengthFor: lastIndex]
		ifFalse: [nowLeftInRun _ leftInRun].
	destY _ lineY + line baseline - font ascent.
	runStopIndex _ lastIndex + (nowLeftInRun - 1) min: line last.
	spaceCount _ 0.
	done _ false.
	string _ text string.
	[done] whileFalse:[
		startIndex _ lastIndex.
		lastPos _ destX@destY.
		stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
						in: string rightX: rightMargin stopConditions: stopConditions
						kern: kern.
		lastIndex >= startIndex ifTrue:[
			font displayString: string on: bitBlt 
				from: startIndex to: lastIndex at: lastPos kern: kern].
		"see setStopConditions for stopping conditions for displaying."
		done _ self perform: stopCondition.
		lastIndex > runStopIndex ifTrue: [done _ true].
	].
	^ runStopIndex - lastIndex   "Number of characters remaining in the current run"