composeLine: lineIndex fromCharacterIndex: startIndex inParagraph: aParagraph 
	"Answer an instance of TextLineInterval that represents the next line in the paragraph."
	| runLength done stopCondition |
	spaceX _ destX _ leftMargin _ aParagraph leftMarginForCompositionForLine: lineIndex.
	destY _ 0.
	rightMargin _ aParagraph rightMarginForComposition.
	leftMargin >= rightMargin ifTrue: [self error: 'No room between margins to compose'].
	lastIndex _ startIndex.	"scanning sets last index"
	lineHeight _ textStyle lineGrid.  "may be increased by setFont:..."
	baseline _ textStyle baseline.
	self setStopConditions.	"also sets font"
	runLength _ text runLengthFor: startIndex.
	runStopIndex _ (lastIndex _ startIndex) + (runLength - 1).
	line _ TextLineInterval
		start: lastIndex
		stop: 0
		internalSpaces: 0
		paddingWidth: 0.
	spaceCount _ 0.
	done _ false.
	[done]
		whileFalse: 
			[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
				in: text string rightX: rightMargin stopConditions: stopConditions
				kern: kern displaying: false.
			"See setStopConditions for stopping conditions for composing."
			(self perform: stopCondition)
				ifTrue: [^line lineHeight: lineHeight + textStyle leading
							baseline: baseline + textStyle leading]]