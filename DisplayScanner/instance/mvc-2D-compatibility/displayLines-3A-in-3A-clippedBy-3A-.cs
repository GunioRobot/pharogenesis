displayLines: linesInterval in: aParagraph clippedBy: visibleRectangle 
	"The central display routine. The call on the primitive 
	(scanCharactersFrom:to:in:rightX:) will be interrupted according to an 
	array of stop conditions passed to the scanner at which time the code to 
	handle the stop condition is run and the call on the primitive continued 
	until a stop condition returns true (which means the line has 
	terminated)."
	"leftInRun is the # of characters left to scan in the current run;
		when 0, it is time to call 'self setStopConditions'"
	| runLength done stopCondition leftInRun startIndex string lastPos |
	morphicOffset := 0 @ 0.
	leftInRun := 0.
	self 
		initializeFromParagraph: aParagraph
		clippedBy: visibleRectangle.
	ignoreColorChanges := false.
	paragraph := aParagraph.
	foregroundColor := paragraphColor := aParagraph foregroundColor.
	backgroundColor := aParagraph backgroundColor.
	aParagraph backgroundColor isTransparent 
		ifTrue: [ fillBlt := nil ]
		ifFalse: 
			[ fillBlt := bitBlt copy.	"Blt to fill spaces, tabs, margins"
			fillBlt
				sourceForm: nil;
				sourceOrigin: 0 @ 0.
			fillBlt fillColor: aParagraph backgroundColor ].
	rightMargin := aParagraph rightMarginForDisplay.
	lineY := aParagraph topAtLineIndex: linesInterval first.
	bitBlt destForm 
		deferUpdatesIn: visibleRectangle
		while: 
			[ linesInterval do: 
				[ :lineIndex | 
				line := aParagraph lines at: lineIndex.
				lastIndex := line first.
				self setStopConditions.	" causes an assignment to inst var.  alignment "
				leftMargin := aParagraph 
					leftMarginForDisplayForLine: lineIndex
					alignment: (alignment ifNil: [ textStyle alignment ]).
				destX := runX := leftMargin.
				line := aParagraph lines at: lineIndex.
				lineHeight := line lineHeight.
				fillBlt == nil ifFalse: 
					[ fillBlt
						destX: visibleRectangle left
							destY: lineY
							width: visibleRectangle width
							height: lineHeight;
						copyBits ].
				lastIndex := line first.
				leftInRun <= 0 ifTrue: 
					[ self setStopConditions.	"also sets the font"
					leftInRun := text runLengthFor: line first ].
				destY := lineY + line baseline - font ascent.	"Should have happened in setFont"
				runLength := leftInRun.
				runStopIndex := lastIndex + (runLength - 1) min: line last.
				leftInRun := leftInRun - (runStopIndex - lastIndex + 1).
				spaceCount := 0.
				done := false.
				string := text string.
				self handleIndentation.
				[ done ] whileFalse: 
					[ startIndex := lastIndex.
					lastPos := destX @ destY.
					stopCondition := self 
						scanCharactersFrom: lastIndex
						to: runStopIndex
						in: string
						rightX: rightMargin
						stopConditions: stopConditions
						kern: kern.
					lastIndex >= startIndex ifTrue: 
						[ font 
							displayString: string
							on: bitBlt
							from: startIndex
							to: lastIndex
							at: lastPos
							kern: kern ].
					"see setStopConditions for stopping conditions for displaying."
					done := self perform: stopCondition ].
				fillBlt == nil ifFalse: 
					[ fillBlt
						destX: destX
							destY: lineY
							width: visibleRectangle right - destX
							height: lineHeight;
						copyBits ].
				lineY := lineY + lineHeight ] ]