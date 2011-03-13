characterBlockAtPoint: aPoint index: index in: textLine
	"This method is the Morphic characterBlock finder.  It combines
	MVC's characterBlockAtPoint:, -ForIndex:, and buildCharcterBlock:in:"
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
			stopConditions: stopConditions kern: kern.
		"see setStopConditions for stopping conditions for character block 	operations."
		self lastCharacterExtentSetX: (specialWidth == nil
			ifTrue: [font widthOf: (text at: lastIndex)]
			ifFalse: [specialWidth]).
		(self perform: stopCondition) ifTrue:
			[characterIndex == nil
				ifTrue: ["Result for characterBlockAtPoint: "
						^ (CharacterBlock new stringIndex: lastIndex
							text: text topLeft: characterPoint + (font descentKern @ 0)
							extent: lastCharacterExtent - (font baseKern @ 0))
									textLine: line]
				ifFalse: ["Result for characterBlockForIndex: "
						^ (CharacterBlock new stringIndex: characterIndex
							text: text topLeft: characterPoint + ((font descentKern) - kern @ 0)
							extent: lastCharacterExtent)
									textLine: line]]]