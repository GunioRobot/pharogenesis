composeLine: lineIndex fromCharacterIndex: startIndex inParagraph: aParagraph 
	"Answer an instance of TextLineInterval that represents the next line in the paragraph."
	| runLength done stopCondition |
	destX _ spaceX _ leftMargin _ aParagraph leftMarginForCompositionForLine: lineIndex.
	destY _ 0.
	rightMargin _ aParagraph rightMarginForComposition.
	leftMargin >= rightMargin ifTrue: [self error: 'No room between margins to compose'].
	lastIndex _ startIndex.	"scanning sets last index"
	lineHeight _ textStyle lineGrid.  "may be increased by setFont:..."
	baseline _ textStyle baseline.
	baselineY _ destY + baseline.
	self setStopConditions.	"also sets font"
	self handleIndentation.
	runLength _ text runLengthFor: startIndex.
	runStopIndex _ (lastIndex _ startIndex) + (runLength - 1).
	line _ TextLineInterval
		start: lastIndex
		stop: 0
		internalSpaces: 0
		paddingWidth: 0.
	presentationLine _ TextLineInterval
		start: lastIndex
		stop: 0
		internalSpaces: 0
		paddingWidth: 0.
	numOfComposition _ 0.
	presentation _ TextStream on: (Text fromString: (MultiString new: text size)).
	spaceCount _ 0.
	done _ false.
	[done]
		whileFalse: 
			[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
				in: text string rightX: rightMargin stopConditions: stopConditions
				kern: kern.
			"See setStopConditions for stopping conditions for composing."
			(self perform: stopCondition)
				ifTrue: [presentationLine lineHeight: lineHeight + textStyle leading
							baseline: baseline + textStyle leading.
						^line lineHeight: lineHeight + textStyle leading
							baseline: baseline + textStyle leading]]