encodedQuote: aString 
	"World addMorph: CipherPanel new"
	| morph prev |
	aString isEmpty
		ifTrue: [^ self].
	(letterMorphs isNil
			or: [self isClean])
		ifFalse: [(self confirm: 'Are you sure you want to discard all typing?' translated)
				ifFalse: [^ self]].
	haveTypedHere := false.
	quote := aString asUppercase.
	prev := nil.
	originalMorphs := quote asArray
				collectWithIndex: [:c :i | WordGameLetterMorph new plain indexInQuote: i id1: nil;
						
						setLetter: (quote at: i)].
	letterMorphs := OrderedCollection new.
	decodingMorphs := quote asArray
				collectWithIndex: [:c :i | (quote at: i) isLetter
						ifTrue: [morph := WordGameLetterMorph new underlined indexInQuote: i id1: nil.
							morph
								on: #mouseDown
								send: #mouseDownEvent:letterMorph:
								to: self.
							morph
								on: #keyStroke
								send: #keyStrokeEvent:letterMorph:
								to: self.
							letterMorphs addLast: morph.
							morph predecessor: prev.
							prev
								ifNotNil: [prev successor: morph].
							prev := morph]
						ifFalse: [WordGameLetterMorph new plain indexInQuote: i id1: nil;
								
								setLetter: (quote at: i)]].
	self color: originalMorphs first color.
	self extent: 500 @ 500