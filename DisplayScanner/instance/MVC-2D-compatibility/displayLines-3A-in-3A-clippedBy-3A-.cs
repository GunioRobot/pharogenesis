displayLines: linesInterval in: aParagraph clippedBy: visibleRectangle
	"The central display routine. The call on the primitive 
	(scanCharactersFrom:to:in:rightX:) will be interrupted according to an 
	array of stop conditions passed to the scanner at which time the code to 
	handle the stop condition is run and the call on the primitive continued 
	until a stop condition returns true (which means the line has 
	terminated)."
	| runLength done stopCondition leftInRun startIndex string lastPos |
	"leftInRun is the # of characters left to scan in the current run;
		when 0, it is time to call 'self setStopConditions'"
	morphicOffset _ 0@0.
	leftInRun _ 0.
	self initializeFromParagraph: aParagraph clippedBy: visibleRectangle.
	ignoreColorChanges _ false.
	paragraph _ aParagraph.
	foregroundColor _ paragraphColor _ aParagraph foregroundColor.
	backgroundColor _ aParagraph backgroundColor.
	aParagraph backgroundColor isTransparent
		ifTrue: [fillBlt _ nil]
		ifFalse: [fillBlt _ bitBlt copy.  "Blt to fill spaces, tabs, margins"
				fillBlt sourceForm: nil; sourceOrigin: 0@0.
				fillBlt fillColor: aParagraph backgroundColor].
	rightMargin _ aParagraph rightMarginForDisplay.
	lineY _ aParagraph topAtLineIndex: linesInterval first.
	bitBlt destForm deferUpdatesIn: visibleRectangle while: [
		linesInterval do: 
			[:lineIndex | 
			line _ aParagraph lines at: lineIndex.
			lastIndex _ line first.
               self setStopConditions. " causes an assignment to inst var.  alignment "

			leftMargin _ aParagraph leftMarginForDisplayForLine: lineIndex alignment: (alignment ifNil:[textStyle alignment]).
			destX _ (runX _ leftMargin).
			line _ aParagraph lines at: lineIndex.
			lineHeight _ line lineHeight.
			fillBlt == nil ifFalse:
				[fillBlt destX: visibleRectangle left destY: lineY
					width: visibleRectangle width height: lineHeight; copyBits].
			lastIndex _ line first.
			leftInRun <= 0
				ifTrue: [self setStopConditions.  "also sets the font"
						leftInRun _ text runLengthFor: line first].
			destY _ lineY + line baseline - font ascent.  "Should have happened in setFont"
			runLength _ leftInRun.
			runStopIndex _ lastIndex + (runLength - 1) min: line last.
			leftInRun _ leftInRun - (runStopIndex - lastIndex + 1).
			spaceCount _ 0.
			done _ false.
			string _ text string.
			self handleIndentation.
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
				done _ self perform: stopCondition].
			fillBlt == nil ifFalse:
				[fillBlt destX: destX destY: lineY width: visibleRectangle right-destX height: lineHeight; copyBits].
			lineY _ lineY + lineHeight]]