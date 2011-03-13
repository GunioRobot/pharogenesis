newContentMorph
	"Answer a new content morph."

	|sp choices|
	self choicesMorph: (choices := self newChoicesMorph).
	sp := GeneralScrollPane new
		scrollTarget: choices;
		hResizing: #spaceFill;
		vResizing: #spaceFill.
	sp
		minWidth: (choices width min: Display width // 2) + sp scrollBarThickness;
		minHeight: (choices height min: Display height // 2).
	choices width > sp minWidth
		ifTrue: [sp minHeight: sp minHeight + sp scrollBarThickness].
	sp
		updateScrollbars.
	^self newGroupboxFor: sp