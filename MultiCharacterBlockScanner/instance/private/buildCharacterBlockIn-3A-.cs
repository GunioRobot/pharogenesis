buildCharacterBlockIn: para
	| lineIndex runLength lineStop done stopCondition |
	"handle nullText"
	(para numberOfLines = 0 or: [text size = 0])
		ifTrue:	[^ CharacterBlock new stringIndex: 1  "like being off end of string"
					text: para text
					topLeft: (para leftMarginForDisplayForLine: 1 alignment: (alignment ifNil:[textStyle alignment]))
								@ para compositionRectangle top
					extent: 0 @ textStyle lineGrid].
	"find the line"
	lineIndex _ para lineIndexOfTop: characterPoint y.
	destY _ para topAtLineIndex: lineIndex.
	line _ para lines at: lineIndex.
	rightMargin _ para rightMarginForDisplay.

	(lineIndex = para numberOfLines and:
		[(destY + line lineHeight) < characterPoint y])
			ifTrue:	["if beyond lastLine, force search to last character"
					self characterPointSetX: rightMargin]
			ifFalse:	[characterPoint y < (para compositionRectangle) top
						ifTrue: ["force search to first line"
								characterPoint _ (para compositionRectangle) topLeft].
					characterPoint x > rightMargin
						ifTrue:	[self characterPointSetX: rightMargin]].
	destX _ (leftMargin _ para leftMarginForDisplayForLine: lineIndex alignment: (alignment ifNil:[textStyle alignment])).
	nextLeftMargin_ para leftMarginForDisplayForLine: lineIndex+1 alignment: (alignment ifNil:[textStyle alignment]).
	lastIndex _ line first.

	self setStopConditions.		"also sets font"
	runLength _ (text runLengthFor: line first).
	characterIndex == nil
		ifTrue:	[lineStop _ line last  "characterBlockAtPoint"]
		ifFalse:	[lineStop _ characterIndex  "characterBlockForIndex"].
	(runStopIndex _ lastIndex + (runLength - 1)) > lineStop
		ifTrue:	[runStopIndex _ lineStop].
	lastCharacterExtent _ 0 @ line lineHeight.
	spaceCount _ 0. done  _ false.
	self handleIndentation.

	[done]
	whileFalse:
	[stopCondition _ self scanCharactersFrom: lastIndex to: runStopIndex
			in: text string rightX: characterPoint x
			stopConditions: stopConditions kern: kern.

	"see setStopConditions for stopping conditions for character block 	operations."
	self lastCharacterExtentSetX: (font widthOf: (text at: lastIndex)).
	(self perform: stopCondition) ifTrue:
		[characterIndex == nil
			ifTrue: ["characterBlockAtPoint"
					^ CharacterBlock new stringIndex: lastIndex text: text
						topLeft: characterPoint + (font descentKern @ 0)
						extent: lastCharacterExtent]
			ifFalse: ["characterBlockForIndex"
					^ CharacterBlock new stringIndex: lastIndex text: text
						topLeft: characterPoint + ((font descentKern) - kern @ 0)
						extent: lastCharacterExtent]]]