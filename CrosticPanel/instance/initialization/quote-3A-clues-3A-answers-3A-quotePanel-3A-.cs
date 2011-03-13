quote: indexableQuote clues: clueStrings answers: answerIndices quotePanel: panel

	| row clue answer answerMorph letterMorph prev clueText clueStyle |
	quote _ indexableQuote.
	quotePanel _ panel.
	clues _ clueStrings.
	answers _ answerIndices.
	cluesPanel _ AlignmentMorph newColumn color: self color;
		hResizing: #shrinkWrap; vResizing: #shrinkWrap;
		cellPositioning: #topLeft; layoutInset: 1.
	letterMorphs _ Array new: quotePanel letterMorphs size.
	clueStyle _ nil.
	1 to: clues size do:
		[:i |  clue _ clues at: i.  answer _ answers at: i.
		row _ AlignmentMorph newRow cellPositioning: #bottomLeft.
		clueText _ (TextMorph newBounds: (0@0 extent: 120@20) color: Color black)
				string: (CrosticPanel oldStyle
							ifTrue: [(($A to: $Z) at: i) asString , '.  ' , clue]
							ifFalse: [clue])
				fontName: 'ComicPlain' size: 13.
		clueStyle ifNil: ["Make up a special style with decreased leading"
						clueStyle _ clueText textStyle copy.
						clueStyle gridForFont: 1 withLead: -2].
		clueText text: clueText asText textStyle: clueStyle.  "All clues share same style"
		clueText composeToBounds.
		row addMorphBack: clueText.
		answerMorph _ AlignmentMorph newRow layoutInset: 0.
		prev _ nil.
		answer do:
			[:n | letterMorph _ WordGameLetterMorph new underlined
						indexInQuote: n
						id1: (CrosticPanel oldStyle ifTrue: [n printString] ifFalse: [nil]);
						setLetter: Character space.
			letterMorph on: #mouseDown send: #mouseDownEvent:letterMorph: to: self.
			letterMorph on: #keyStroke send: #keyStrokeEvent:letterMorph: to: self.
			letterMorph predecessor: prev.
			prev ifNotNil: [prev successor: letterMorph].
			prev _ letterMorph.
			letterMorphs at: n put: letterMorph.
			answerMorph addMorphBack: letterMorph].
		answerMorph color: answerMorph firstSubmorph color.
		row addMorphBack: answerMorph.
row fullBounds.
		row color: answerMorph firstSubmorph color.
		cluesPanel addMorphBack: row].
	self addMorph: cluesPanel.
	self bounds: cluesPanel fullBounds.
