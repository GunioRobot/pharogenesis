encodedQuote: aString
	"World addMorph: CipherPanel test"

	| morph prev |
	haveTypedHere _ false.
	quote _ aString asUppercase.
	prev _ nil.
	originalMorphs _ quote asArray collectWithIndex:
		[:c :i | WordGameLetterMorph new plain indexInQuote: i id1: nil;
						setLetter: (quote at: i)].
	letterMorphs _ OrderedCollection new.
	decodingMorphs _ quote asArray collectWithIndex:
		[:c :i | (quote at: i) isLetter
		ifTrue:
			[morph _ WordGameLetterMorph new underlined indexInQuote: i id1: nil.
			morph on: #mouseDown send: #mouseDownEvent:letterMorph: to: self.
			morph on: #keyStroke send: #keyStrokeEvent:letterMorph: to: self.
			letterMorphs addLast: morph.
			morph predecessor: prev.
			prev ifNotNil: [prev successor: morph].
			prev _ morph]
		ifFalse:
			[WordGameLetterMorph new plain indexInQuote: i id1: nil; setLetter: (quote at: i)]].
	self color: originalMorphs first color.
	self extent: 500@500
