scanMultiCharactersCombiningFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| charCode encoding f maxAscii startEncoding combining combined combiningIndex c |
	lastIndex := startIndex.
	lastIndex > stopIndex ifTrue: [lastIndex := stopIndex. ^ stops at: EndOfRun].
	startEncoding := (sourceString at: startIndex) leadingChar.
	font ifNil: [font := (TextConstants at: #DefaultMultiStyle) fontArray at: 1].
	((font isMemberOf: StrikeFontSet) or: [font isKindOf: TTCFontSet]) ifTrue: [
		[f := font fontArray at: startEncoding + 1]
			on: Exception do: [:ex | f := font fontArray at: 1].
		f ifNil: [ f := font fontArray at: 1].
		maxAscii := f maxAscii.
		spaceWidth := font widthOf: Space.
	] ifFalse: [
		maxAscii := font maxAscii.
		spaceWidth := font widthOf: Space.
	].

	combining := nil.
	[lastIndex <= stopIndex] whileTrue: [
		charCode := (sourceString at: lastIndex) charCode.
		c := (sourceString at: lastIndex).
		combining ifNil: [
			combining := CombinedChar new.
			combining add: c.
			combiningIndex := lastIndex.
			lastIndex := lastIndex + 1.
		] ifNotNil: [
			(combining add: c) ifFalse: [
				self addCharToPresentation: (combined := combining combined).
				combining := CombinedChar new.
				combining add: c.
				charCode := combined charCode.
				encoding := combined leadingChar.
				encoding ~= startEncoding ifTrue: [lastIndex := lastIndex - 1.
					(encoding = 0 and: [(stopConditions at: charCode + 1) ~~ nil]) ifTrue: [
						^ stops at: charCode + 1
					] ifFalse: [
						 ^ stops at: EndOfRun
					].
				].
				charCode > maxAscii ifTrue: [charCode := maxAscii].
				""
				(encoding = 0 and: [(stopConditions at: charCode + 1) ~~ nil]) ifTrue: [
					combining ifNotNil: [
						self addCharToPresentation: (combining combined).
					].
					^ stops at: charCode + 1
				].
				(self isBreakableAt: lastIndex in: sourceString in: Latin1Environment) ifTrue: [
					self registerBreakableIndex.
				].		
				destX > rightX ifTrue: [
					destX ~= firstDestX ifTrue: [
						lastIndex := combiningIndex.
						self removeLastCharFromPresentation.
						^ stops at: CrossedX]].
				combiningIndex := lastIndex.
				lastIndex := lastIndex + 1.
			] ifTrue: [
				lastIndex := lastIndex + 1.
				numOfComposition := numOfComposition + 1.
			].
		].
	].
	lastIndex := stopIndex.
	combining ifNotNil: [
		combined := combining combined.
		self addCharToPresentation: combined.
		"assuming that there is always enough space for at least one character".
		destX := destX + (self widthOf: combined inFont: font).
	].
	^ stops at: EndOfRun