quote: indexableQuote clues: clueStrings answers: answerIndices quotePanel: panel

	| row clue answer answerMorph letterMorph prev |
	quote _ indexableQuote.
	quotePanel _ panel.
	clues _ clueStrings.
	answers _ answerIndices.
	cluesPanel _ AlignmentMorph newColumn color: self color;
		hResizing: #shrinkWrap; vResizing: #shrinkWrap; inset: 0.
	letterMorphs _ Array new: quotePanel letterMorphs size.
	1 to: clues size do:
		[:i |  clue _ clues at: i.  answer _ answers at: i.
		row _ AlignmentMorph newRow hResizing: #shrinkWrap; vResizing: #shrinkWrap.
		row addMorphBack:
			((TextMorph newBounds: (0@0 extent: 120@20) color: Color black)
				string: (CrosticPanel oldStyle
							ifTrue: [(($A to: $Z) at: i) asString , '.  ' , clue]
							ifFalse: [clue])
					fontName: 'ComicPlain' size: 13).
		row addTransparentSpacerOfSize: (3 @ 0).
		answerMorph _ AlignmentMorph newRow inset: 0;
			hResizing: #shrinkWrap; vResizing: #shrinkWrap.
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
		row color: answerMorph firstSubmorph color.
		cluesPanel addMorphBack: row].
	self addMorph: cluesPanel.
cluesPanel imageForm.  "Needed for some sort of resizing!"
	self bounds: cluesPanel fullBounds.
