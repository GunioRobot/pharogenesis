scanMultiCharactersR2LFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	"Note that 'rightX' really means 'endX' in R2L context.  Ie.  rightX is usually smaller than destX."
	| ascii encoding f nextDestX maxAscii startEncoding |
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
		ascii := (sourceString at: lastIndex) charCode.
		ascii > maxAscii ifTrue: [ascii := maxAscii].
		(encoding = 0 and: [(stopConditions at: ascii + 1) ~~ nil]) ifTrue: [^ stops at: ascii + 1].
		(self isBreakableAt: lastIndex in: sourceString in: Latin1Environment) ifTrue: [
			self registerBreakableIndex.
		].
		nextDestX := destX - (font widthOf: (sourceString at: lastIndex)).
		nextDestX < rightX ifTrue: [^ stops at: CrossedX].
		destX := nextDestX - kernDelta.
		lastIndex := lastIndex + 1.
	].
	lastIndex := stopIndex.
	^ stops at: EndOfRun