scanMultiCharactersCombiningFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| encoding f nextDestX maxAscii startEncoding char charValue |
	lastIndex _ startIndex.
	lastIndex > stopIndex ifTrue: [lastIndex _ stopIndex. ^ stops at: EndOfRun].
	startEncoding _ (sourceString at: startIndex) leadingChar.
	font ifNil: [font _ (TextConstants at: #DefaultMultiStyle) fontArray at: 1].
	((font isMemberOf: StrikeFontSet) or: [font isKindOf: TTCFontSet]) ifTrue: [
		[f _ font fontArray at: startEncoding + 1]
			on: Exception do: [:ex | f _ font fontArray at: 1].
		f ifNil: [ f _ font fontArray at: 1].
		maxAscii _ f maxAscii.
		spaceWidth _ f widthOf: Space.
	] ifFalse: [
		maxAscii _ font maxAscii.
	].

	[lastIndex <= stopIndex] whileTrue: [
		encoding _ (sourceString at: lastIndex) leadingChar.
		encoding ~= startEncoding ifTrue: [lastIndex _ lastIndex - 1. ^ stops at: EndOfRun].
		char _ (sourceString at: lastIndex).
		charValue _ char charCode.
		charValue > maxAscii ifTrue: [charValue _ maxAscii].
		(encoding = 0 and: [(stopConditions at: charValue + 1) ~~ nil]) ifTrue: [
			^ stops at: charValue + 1
		].
		nextDestX _ destX + (self widthOf: char inFont: font).
		nextDestX > rightX ifTrue: [^ stops at: CrossedX].
		destX _ nextDestX + kernDelta.
		lastIndex _ lastIndex + 1.
	].
	lastIndex _ stopIndex.
	^ stops at: EndOfRun