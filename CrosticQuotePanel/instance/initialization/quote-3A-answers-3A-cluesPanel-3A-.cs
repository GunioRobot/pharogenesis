quote: quoteWithBlanks answers: theAnswers cluesPanel: panel

	| n morph prev clueIxs |
	cluesPanel _ panel.
	self color: Color gray.
	clueIxs _ Array new: quoteWithBlanks size.
	theAnswers withIndexDo: [:a :i | a do: [:j | clueIxs at: j put: i]].
	letterMorphs _ OrderedCollection new.
	prev _ nil.
	self addAllMorphs: (quoteWithBlanks asArray collect:
		[:c |
		c isLetter
			ifTrue: [n _ letterMorphs size + 1.
					morph _ WordGameLetterMorph new boxed.
					CrosticPanel oldStyle
						ifTrue: [morph indexInQuote: n id1: n printString.
								morph id2: (($A to: $Z) at: (clueIxs at: n)) asString]
						ifFalse: [morph indexInQuote: n id1: nil].
					morph setLetter: Character space.
					morph on: #mouseDown send: #mouseDownEvent:letterMorph: to: self.
					morph on: #keyStroke send: #keyStrokeEvent:letterMorph: to: self.
					letterMorphs addLast: morph]
			ifFalse: [morph _ WordGameLetterMorph new boxed indexInQuote: nil id1: nil.
					CrosticPanel oldStyle ifTrue: [morph extent: 26@24  "Oops"]].
		morph predecessor: prev.
		prev ifNotNil: [prev successor: morph].
		prev _ morph]).
