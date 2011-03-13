scanMultiCharactersCombiningFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| encoding f nextDestX maxAscii startEncoding char charValue floatDestX widthAndKernedWidth nextChar |
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
	floatDestX := destX.
	widthAndKernedWidth := Array new: 2.
	[lastIndex <= stopIndex] whileTrue: [
		encoding := (sourceString at: lastIndex) leadingChar.
		encoding ~= startEncoding ifTrue: [lastIndex := lastIndex - 1. ^ stops at: EndOfRun].
		char := (sourceString at: lastIndex).
		charValue := char charCode.
		charValue > maxAscii ifTrue: [charValue := maxAscii].
		(encoding = 0 and: [(stopConditions at: charValue + 1) ~~ nil]) ifTrue: [
			^ stops at: charValue + 1
		].
		nextChar := (lastIndex + 1 <= stopIndex) 
			ifTrue:[sourceString at: lastIndex + 1]
			ifFalse:[nil].
		font 
			widthAndKernedWidthOfLeft: ((char isMemberOf: CombinedChar) ifTrue:[char base] ifFalse:[char]) 
			right: nextChar
			into: widthAndKernedWidth.
		nextDestX := floatDestX + (widthAndKernedWidth at: 1).	
		nextDestX > rightX ifTrue: [^ stops at: CrossedX].
		floatDestX := floatDestX + kernDelta + (widthAndKernedWidth at: 2).
		destX := floatDestX.
		lastIndex := lastIndex + 1.
	].
	lastIndex := stopIndex.
	^ stops at: EndOfRun