setLetter: aLetter color: aColor

	letterMorph ifNotNil: [letterMorph delete].
	letter _ aLetter.
	letter ifNil: [^ letterMorph _ nil].
	letterMorph _ StringMorph contents: aLetter asString font: LetterFont.
	letterMorph color: aColor.
	style == #boxed
		ifTrue:
		[letterMorph align: letterMorph bounds bottomCenter
					with: self bounds bottomCenter + (0@(LetterFont descent-2))]
		ifFalse:
		[lineMorph == nil
		ifTrue: [letterMorph align: letterMorph bounds bottomCenter
						with: self bounds bottomCenter + (0@(LetterFont descent-4))]
		ifFalse: [letterMorph align: letterMorph bounds bottomCenter
						with: self center x@(lineMorph top + LetterFont descent)]].
	self addMorphBack: letterMorph.

