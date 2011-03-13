scanMultiCharactersCombiningFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta

	| charCode encoding f maxAscii startEncoding combining combined combiningIndex c |
	lastIndex _ startIndex.
	lastIndex > stopIndex ifTrue: [lastIndex _ stopIndex. ^ stops at: EndOfRun].
	startEncoding _ (sourceString at: startIndex) leadingChar.
	font ifNil: [font _ (TextConstants at: #DefaultMultiStyle) fontArray at: 1].
	((font isMemberOf: StrikeFontSet) or: [font isKindOf: TTCFontSet]) ifTrue: [
		[f _ font fontArray at: startEncoding + 1]
			on: Exception do: [:ex | f _ font fontArray at: 1].
		f ifNil: [ f _ font fontArray at: 1].
		maxAscii _ f maxAscii.
		spaceWidth _ font widthOf: Space.
	] ifFalse: [
		maxAscii _ font maxAscii.
		spaceWidth _ font widthOf: Space.
	].

	combining _ nil.
	[lastIndex <= stopIndex] whileTrue: [
		charCode _ (sourceString at: lastIndex) charCode.
		c _ (sourceString at: lastIndex).
		combining ifNil: [
			combining _ CombinedChar new.
			combining add: c.
			combiningIndex _ lastIndex.
			lastIndex _ lastIndex + 1.
		] ifNotNil: [
			(combining add: c) ifFalse: [
				self addCharToPresentation: (combined _ combining combined).
				combining _ CombinedChar new.
				combining add: c.
				charCode _ combined charCode.
				encoding _ combined leadingChar.
				encoding ~= startEncoding ifTrue: [lastIndex _ lastIndex - 1.
					(encoding = 0 and: [(stopConditions at: charCode + 1) ~~ nil]) ifTrue: [
						^ stops at: charCode + 1
					] ifFalse: [
						 ^ stops at: EndOfRun
					].
				].
				charCode > maxAscii ifTrue: [charCode _ maxAscii].
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
						lastIndex _ combiningIndex.
						self removeLastCharFromPresentation.
						^ stops at: CrossedX]].
				combiningIndex _ lastIndex.
				lastIndex _ lastIndex + 1.
			] ifTrue: [
				lastIndex _ lastIndex + 1.
				numOfComposition _ numOfComposition + 1.
			].
		].
	].
	lastIndex _ stopIndex.
	combining ifNotNil: [
		combined _ combining combined.
		self addCharToPresentation: combined.
		"assuming that there is always enough space for at least one character".
		destX _ destX + (self widthOf: combined inFont: font).
	].
	^ stops at: EndOfRun