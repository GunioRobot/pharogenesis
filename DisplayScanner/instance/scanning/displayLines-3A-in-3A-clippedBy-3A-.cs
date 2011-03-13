displayLines: linesInterval in: aParagraph clippedBy: visibleRectangle 
	"The central display routine. The call on the primitive 
	(scanCharactersFrom:to:in:rightX:) will be interrupted according to an 
	array of stop conditions passed to the scanner at which time the code to 
	handle the stop condition is run and the call on the primitive continued 
	until a stop condition returns true (which means the line has 
	terminated)."

	| runLength done lineGrid lineIndex stopCondition leftInRun fore back |
	"leftInRun is the # of characters left to scan in the current run; when 0,
		it is time to call 'self setStopConditions'"
	leftInRun _ 0.
	super initializeFromParagraph: aParagraph clippedBy: visibleRectangle.
	destForm depth > 1 ifTrue:
		[fore _ aParagraph foregroundColor bitPatternForDepth: destForm depth.
		back _ aParagraph backgroundColor bitPatternForDepth: destForm depth.
		self colorMap: (Bitmap with: back first with: fore first)].
	rightMargin _ aParagraph rightMarginForDisplay.
	lineGrid _ textStyle lineGrid.
	lineY _ destY _ aParagraph topAtLineIndex: linesInterval first.
	linesInterval do: 
		[:lineIndex | 
		runX _ destX _ leftMargin _ 
			aParagraph leftMarginForDisplayForLine: lineIndex.
		line _ aParagraph lines at: lineIndex.
		lastIndex _ line first.
		leftInRun<= 0 
			ifTrue:
				[self setStopConditions.
				"also sets the font"
				leftInRun _ text runLengthFor: line first].
		runLength _ leftInRun.
		destY _ lineY + (textStyle baseline - font ascent).
		"fontAscent delta"
		(runStopIndex _ lastIndex + (runLength - 1)) > line last 
			ifTrue: [runStopIndex _ line last].
		leftInRun _ leftInRun - (runStopIndex - lastIndex + 1).
		spaceCount _ 0.
		done _ false.
		[done]
			whileFalse: 
				[stopCondition _ 
					self scanCharactersFrom: lastIndex
						to: runStopIndex
						in: text string
						rightX: rightMargin
						stopConditions: stopConditions
						displaying: true.
				"see setStopConditions for stopping conditions for displaying."
				done _ self perform: stopCondition].
		lineY _ lineY + lineGrid]