buildCharacterBlockIn: aText

	| lineIndex runLength lineStop done stopCondition |
	"handle nullText"
	(aText numberOfLines = 0 or: [text size = 0])
		ifTrue:	[^CharacterBlock
					stringIndex: 1	"like being off end of string"
					character: nil
					topLeft: ((aText leftMarginForDisplayForLine: 1) @
								(aText compositionRectangle) top)
					extent: (0 @ textStyle lineGrid)].

	"find the line"
	lineIndex _ aText lineIndexOfTop: characterPoint y.
	destY _ (aText topAtLineIndex: lineIndex).
	line _ aText lines at: lineIndex.
	rightMargin _ aText rightMarginForDisplay.

	(lineIndex = aText numberOfLines and:
		[(destY + textStyle lineGrid) < characterPoint y])
			ifTrue:	["if beyond lastLine, force search to last character"
					characterPoint x: rightMargin]
			ifFalse:	[characterPoint y < (aText compositionRectangle) top
						ifTrue: ["force search to first line"
								characterPoint _
								(aText compositionRectangle) topLeft].
					characterPoint x > rightMargin
						ifTrue:	[characterPoint x: rightMargin]].
	destX _ leftMargin _ aText leftMarginForDisplayForLine: lineIndex.
	nextLeftMargin_ aText leftMarginForDisplayForLine: lineIndex+1.
	lastIndex _ line first.

	self setStopConditions.		"also sets font"
	runLength _ (text runLengthFor: line first).
	characterIndex ~~ nil
		ifTrue:	[lineStop _ characterIndex	"scanning for index"]
		ifFalse:	[lineStop _ line last].
	(runStopIndex _ lastIndex + (runLength - 1)) > lineStop
		ifTrue:	[runStopIndex _ lineStop].
	lastCharacterExtent _ 0 @ textStyle lineGrid.
	spaceCount _ 0. done  _ false.

	[done]
	whileFalse:
	[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
			in: text string rightX: characterPoint x
			stopConditions: stopConditions displaying: false.

	"see setStopConditions for stopping conditions for character block 	operations."
	lastCharacterExtent x: (font widthOf: (text at: lastIndex)).
	(self perform: stopCondition)
		ifTrue:	[^CharacterBlock
					stringIndex: lastIndex
					character: lastCharacter
					topLeft: characterPoint
					extent: lastCharacterExtent]]