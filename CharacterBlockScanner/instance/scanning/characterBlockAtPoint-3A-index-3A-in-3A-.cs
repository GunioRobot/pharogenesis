characterBlockAtPoint: aPoint index: index in: textLine
	| runLength lineStop done stopCondition |
	line _ textLine.
	characterIndex _ index.  " == nil means scanning for point"
	characterPoint _ aPoint.
	(characterPoint == nil or: [characterPoint y > line bottom])
		ifTrue: [characterPoint _ line bottomRight].
	(text isEmpty or: [(characterPoint y < line top or: [characterPoint x < line left])
				or: [characterIndex ~~ nil and: [characterIndex < line first]]])
		ifTrue:	[^ (CharacterBlock new stringIndex: line first text: text
					topLeft: line leftMargin@line top extent: 0 @ textStyle lineGrid)
					textLine: line].
	rightMargin _ line rightMargin.
	destX _ leftMargin _ line leftMarginForAlignment: textStyle alignment.
	destY _ line top.
	lastIndex _ line first.
	self setStopConditions.		"also sets font"
	runLength _ text runLengthFor: line first.
	characterIndex ~~ nil
		ifTrue:	[lineStop _ characterIndex  "scanning for index"]
		ifFalse:	[lineStop _ line last  "scanning for point"].
	runStopIndex _ lastIndex + (runLength - 1) min: lineStop.
	lastCharacterExtent _ 0 @ line lineHeight.
	spaceCount _ 0.

	done  _ false.
	[done] whileFalse:
		[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
			in: text string rightX: characterPoint x
			stopConditions: stopConditions kern: kern displaying: false.
		"see setStopConditions for stopping conditions for character block 	operations."
		self lastCharacterExtentSetX: (specialWidth == nil
			ifTrue: [font widthOf: (text at: lastIndex)]
			ifFalse: [specialWidth]).
		(self perform: stopCondition) ifTrue:
			[^ (CharacterBlock new
				stringIndex: (characterIndex==nil ifTrue: [lastIndex] ifFalse: [characterIndex])
				text: text topLeft: characterPoint extent: lastCharacterExtent)
				textLine: line]]