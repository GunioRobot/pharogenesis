composeLinesFrom: argStart to: argStop delta: argDelta into: argLinesCollection priorLines: argPriorLines atY: argStartY textStyle: argTextStyle text: argText container: argContainer wantsColumnBreaks: argWantsColumnBreaks

	wantsColumnBreaks _ argWantsColumnBreaks.
	lines _ argLinesCollection.
	theTextStyle _ argTextStyle.
	theText _ argText.
	theContainer _ argContainer.
	deltaCharIndex _ argDelta.
	currCharIndex _ startCharIndex _ argStart.
	stopCharIndex _ argStop.
	prevLines _ argPriorLines.
	currentY _ argStartY.
	defaultLineHeight _ theTextStyle lineGrid.
	maxRightX _ theContainer left.
	possibleSlide _ stopCharIndex < theText size and: [theContainer isMemberOf: Rectangle].
	nowSliding _ false.
	prevIndex _ 1.
	scanner _ CompositionScanner new text: theText textStyle: theTextStyle.
	scanner wantsColumnBreaks: wantsColumnBreaks.
	isFirstLine _ true.
	self composeAllLines.
	isFirstLine ifTrue: ["No space in container or empty text"
		self 
			addNullLineWithIndex: startCharIndex
			andRectangle: (theContainer topLeft extent: 0@defaultLineHeight)
	] ifFalse: [
		self fixupLastLineIfCR
	].
	^{lines asArray. maxRightX}

