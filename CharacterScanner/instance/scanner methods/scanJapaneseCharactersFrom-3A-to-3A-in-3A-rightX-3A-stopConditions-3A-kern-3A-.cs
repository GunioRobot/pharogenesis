scanJapaneseCharactersFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| ascii encoding f nextDestX maxAscii startEncoding |
	lastIndex _ startIndex.
	lastIndex > stopIndex ifTrue: [lastIndex _ stopIndex. ^ stops at: EndOfRun].
	startEncoding _ (sourceString at: startIndex) leadingChar.
	font ifNil: [font _ (TextConstants at: #DefaultMultiStyle) fontArray at: 1].
	((font isMemberOf: StrikeFontSet) or: [font isKindOf: TTCFontSet]) ifTrue: [
		maxAscii _ font maxAsciiFor: startEncoding.
		f _ font fontArray at: startEncoding + 1.
		"xTable _ f xTable.
		maxAscii _ xTable size - 2."
		spaceWidth _ f widthOf: Space.
	] ifFalse: [
		maxAscii _ font maxAscii.
	].
	[lastIndex <= stopIndex] whileTrue: [
		encoding _ (sourceString at: lastIndex) leadingChar.
		encoding ~= startEncoding ifTrue: [lastIndex _ lastIndex - 1. ^ stops at: EndOfRun].
		ascii _ (sourceString at: lastIndex) charCode.
		ascii > maxAscii ifTrue: [ascii _ maxAscii].
		(encoding = 0 and: [(stopConditions at: ascii + 1) ~~ nil]) ifTrue: [^ stops at: ascii + 1].
		nextDestX _ destX + (font widthOf: (sourceString at: lastIndex)).
		nextDestX > rightX ifTrue: [^ stops at: CrossedX].
		destX _ nextDestX + kernDelta.
		"destX printString displayAt: 0@(lastIndex*20)."
		lastIndex _ lastIndex + 1.
	].
	lastIndex _ stopIndex.
	^ stops at: EndOfRun