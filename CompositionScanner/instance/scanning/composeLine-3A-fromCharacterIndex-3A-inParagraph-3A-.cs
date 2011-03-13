composeLine: lineIndex fromCharacterIndex: startIndex inParagraph: aParagraph 
	"Answer an instance of TextLineInterval that represents the next line in the paragraph. "
	
	| runLengtrh done stopCondition |
	spaceX _ destX _ leftMargin _ aParagraph leftMarginForCompositionForLine: lineIndex.
	destY _ 0.
	rightMargin _ aParagraph rightMarginForComposition.
	leftMargin >= rightMargin ifTrue: [self error: 'No room between margins to compose'].
	lastIndex _ startIndex.	"scanning sets last index"
	self setStopConditions.	"also sets font"
	runLengtrh _ text runLengthFor: startIndex.
	runStopIndex _ (lastIndex _ startIndex) + (runLengtrh - 1).
	line _ TextLineInterval
		start: lastIndex
		stop: 0
		internalSpaces: 0
		paddingWidth: 0.
	spaceCount _ 0.
	done _ false.
	[done]
		whileFalse: 
			[stopCondition _ super
				scanCharactersFrom: lastIndex
				to: runStopIndex
				in: text string
				rightX: rightMargin
				stopConditions: stopConditions
				displaying: false.
			"See setStopConditions for stopping conditions for composing."
			(self perform: stopCondition)
				ifTrue: [^line]]