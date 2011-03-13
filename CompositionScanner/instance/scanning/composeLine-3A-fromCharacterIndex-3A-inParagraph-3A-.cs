composeLine: lineIndex fromCharacterIndex: startIndex inParagraph: aParagraph 
	"Answer an instance of TextLineInterval that represents the next line in the paragraph."
	| runLength done stopCondition |
	destX := spaceX := leftMargin := aParagraph leftMarginForCompositionForLine: lineIndex.
	destY := 0.
	rightMargin := aParagraph rightMarginForComposition.
	leftMargin >= rightMargin ifTrue: [ self error: 'No room between margins to compose' ].
	lastIndex := startIndex.	"scanning sets last index"
	lineHeight := textStyle lineGrid.	"may be increased by setFont:..."
	baseline := textStyle baseline.
	self setStopConditions.	"also sets font"
	self handleIndentation.
	runLength := text runLengthFor: startIndex.
	runStopIndex := (lastIndex := startIndex) + (runLength - 1).
	line := TextLineInterval 
		start: lastIndex
		stop: 0
		internalSpaces: 0
		paddingWidth: 0.
	spaceCount := 0.
	done := false.
	[ done ] whileFalse: 
		[ stopCondition := self 
			scanCharactersFrom: lastIndex
			to: runStopIndex
			in: text string
			rightX: rightMargin
			stopConditions: stopConditions
			kern: kern.
		"See setStopConditions for stopping conditions for composing."
		(self perform: stopCondition) ifTrue: 
			[ ^ line 
				lineHeight: lineHeight + textStyle leading
				baseline: baseline + textStyle leading ] ]