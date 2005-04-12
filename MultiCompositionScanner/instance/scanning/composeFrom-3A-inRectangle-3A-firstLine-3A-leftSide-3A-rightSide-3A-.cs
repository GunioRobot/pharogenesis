composeFrom: startIndex inRectangle: lineRectangle
	firstLine: firstLine leftSide: leftSide rightSide: rightSide
	"Answer an instance of TextLineInterval that represents the next line in the paragraph."
	| runLength done stopCondition |
	"Set up margins"
	leftMargin _ lineRectangle left.
	leftSide ifTrue: [leftMargin _ leftMargin +
						(firstLine ifTrue: [textStyle firstIndent]
								ifFalse: [textStyle restIndent])].
	destX _ spaceX _ leftMargin.
	firstDestX _ destX.
	rightMargin _ lineRectangle right.
	rightSide ifTrue: [rightMargin _ rightMargin - textStyle rightIndent].
	lastIndex _ startIndex.	"scanning sets last index"
	destY _ lineRectangle top.
	lineHeight _ baseline _ 0.  "Will be increased by setFont"
	self setStopConditions.	"also sets font"
	runLength _ text runLengthFor: startIndex.
	runStopIndex _ (lastIndex _ startIndex) + (runLength - 1).
	line _ (TextLine start: lastIndex stop: 0 internalSpaces: 0 paddingWidth: 0)
				rectangle: lineRectangle.
	presentationLine _ (TextLine start: lastIndex stop: 0 internalSpaces: 0 paddingWidth: 0)
				rectangle: lineRectangle.
	numOfComposition _ 0.
	spaceCount _ 0.
	self handleIndentation.
	leftMargin _ destX.
	line leftMargin: leftMargin.
	presentationLine leftMargin: leftMargin.

	presentation _ TextStream on: (Text fromString: (WideString new: text size)).

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
						^ line lineHeight: lineHeight + textStyle leading
							baseline: baseline + textStyle leading]]