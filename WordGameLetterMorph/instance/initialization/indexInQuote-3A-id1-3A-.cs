indexInQuote: qi id1: idString
	"Initialize me with the given index and an optional idString"

	| idMorph y |
	style = #boxed
		ifTrue: [idString == nil
				ifTrue: [self extent: 18@16; borderWidth: 1]
				ifFalse: [self extent: 26@24; borderWidth: 1]]
		ifFalse: [idString == nil
				ifTrue: [self extent: 18@16; borderWidth: 0]
				ifFalse: [self extent: 18@26; borderWidth: 0]].
	qi ifNil: [^ self color: Color gray].  "blank"
	self color: self normalColor.
	indexInQuote _ qi.
	style == #underlined
	ifTrue:
		[y _ self bottom - 2.
		idString ifNotNil: [y _ y - IDFont ascent + 2].
		lineMorph _ PolygonMorph
				vertices: {self left+2@y. self right-3@y}
				color: Color gray borderWidth: 1 borderColor: Color gray.
		self addMorph: lineMorph.
		idString ifNil: [^ self].
		idMorph _ StringMorph contents: idString font: IDFont.
		idMorph align: idMorph bounds bottomCenter
				with: self bounds bottomCenter + (0@(IDFont descent-1)).
		self addMorphBack: idMorph]
	ifFalse:
		[idString ifNil: [^ self].
		idMorph _ StringMorph contents: idString font: IDFont.
		idMorph align: idMorph bounds topLeft with: self bounds topLeft + (2@-1).
		self addMorph: idMorph]
"
World addMorph: (WordGameLetterMorph new boxed indexInQuote: 123 id1: '123';
							id2: 'H'; setLetter: $W).
World addMorph: (WordGameLetterMorph new underlined indexInQuote: 123 id1: '123';
							setLetter: $W).
World addMorph: (WordGameLetterMorph new underlined indexInQuote: 123 id1: nil;
							setLetter: $W).
"

