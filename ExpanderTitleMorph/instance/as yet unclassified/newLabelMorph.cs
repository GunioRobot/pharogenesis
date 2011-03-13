newLabelMorph
	"Answer a new label morph for the receiver."

	^TextMorph new
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		margins: (3@3 corner: 3@0);
		lock