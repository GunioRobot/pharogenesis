displayLine: textLine  offset: offset  leftInRun: leftInRun
	|  nowLeftInRun done startLoc startIndex stopCondition |
	"largely copied from DisplayScanner's routine"

	line := textLine.
	foregroundColor ifNil: [ foregroundColor := Color black ].
	leftMargin := (line leftMarginForAlignment: alignment) + offset x.

	rightMargin := line rightMargin + offset x.
	lineY := line top + offset y.
	lastIndex := textLine first.
	leftInRun <= 0
		ifTrue: [self setStopConditions.  "also sets the font"
				nowLeftInRun := text runLengthFor: lastIndex]
		ifFalse: [nowLeftInRun := leftInRun].
	runX := destX := leftMargin.

	runStopIndex := lastIndex + (nowLeftInRun - 1) min: line last.
	spaceCount := 0.
	done := false.

	[done] whileFalse: [
		"remember where this portion of the line starts"
		startLoc := destX@destY.
		startIndex := lastIndex.

		"find the end of this portion of the line"
		stopCondition := self scanCharactersFrom: lastIndex to: runStopIndex
						in: text string rightX: rightMargin stopConditions: stopConditions
						kern: kern "displaying: false".

		"display that portion of the line"
		canvas drawString: text string
			from: startIndex to: lastIndex
			at: startLoc
			font: font
			color: foregroundColor.

		"handle the stop condition"
		done := self perform: stopCondition
	].

	^runStopIndex - lastIndex