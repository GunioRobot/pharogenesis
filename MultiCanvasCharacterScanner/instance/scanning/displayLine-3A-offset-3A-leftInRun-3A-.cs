displayLine: textLine  offset: offset  leftInRun: leftInRun
	|  nowLeftInRun done startLoc startIndex stopCondition |
	"largely copied from DisplayScanner's routine"

	line _ textLine.
	foregroundColor ifNil: [ foregroundColor _ Color black ].
	leftMargin _ (line leftMarginForAlignment: alignment) + offset x.

	rightMargin _ line rightMargin + offset x.
	lineY _ line top + offset y.
	lastIndex _ textLine first.
	leftInRun <= 0
		ifTrue: [self setStopConditions.  "also sets the font"
				nowLeftInRun _ text runLengthFor: lastIndex]
		ifFalse: [nowLeftInRun _ leftInRun].
	runX _ destX _ leftMargin.

	runStopIndex _ lastIndex + (nowLeftInRun - 1) min: line last.
	spaceCount _ 0.
	done _ false.

	[done] whileFalse: [
		"remember where this portion of the line starts"
		startLoc _ destX@destY.
		startIndex _ lastIndex.

		"find the end of this portion of the line"
		stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
						in: text string rightX: rightMargin stopConditions: stopConditions
						kern: kern "displaying: false".

		"display that portion of the line"
		canvas drawString: text string
			from: startIndex to: lastIndex
			at: startLoc
			font: font
			color: foregroundColor.

		"handle the stop condition"
		done _ self perform: stopCondition
	].

	^runStopIndex - lastIndex