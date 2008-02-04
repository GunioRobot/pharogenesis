scanMultiCharactersCombiningFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| encoding f nextDestX maxAscii startEncoding char charValue |
	lastIndex := startIndex.
	lastIndex > stopIndex ifTrue: [lastIndex := stopIndex. ^ stops at: EndOfRun].
	startEncoding := (sourceString at: startIndex) leadingChar.
	font ifNil: [font := (TextConstants at: #DefaultMultiStyle) fontArray at: 1].
	((font isMemberOf: StrikeFontSet) or: [font isKindOf: TTCFontSet]) ifTrue: [
		[f := font fontArray at: startEncoding + 1]
			on: Exception do: [:ex | f := font fontArray at: 1].
		f ifNil: [ f := font fontArray at: 1].
		maxAscii := f maxAscii.
		spaceWidth := f widthOf: Space.
	] ifFalse: [
		maxAscii := font maxAscii.
	].

	[lastIndex <= stopIndex] whileTrue: [
		encoding := (sourceString at: lastIndex) leadingChar.
		encoding ~= startEncoding ifTrue: [lastIndex := lastIndex - 1. ^ stops at: EndOfRun].
		char := (sourceString at: lastIndex).
		charValue := char charCode.
		charValue > maxAscii ifTrue: [charValue := maxAscii].
		(encoding = 0 and: [(stopConditions at: charValue + 1) ~~ nil]) ifTrue: [
			^ stops at: charValue + 1
		].
		nextDestX := destX + (self widthOf: char inFont: font).
		nextDestX > rightX ifTrue: [^ stops at: CrossedX].
		destX := nextDestX + kernDelta.
		lastIndex := lastIndex + 1.
	].
	lastIndex := stopIndex.
	^ stops at: EndOfRun