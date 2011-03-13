pushPane: aMorph
	aMorph 
		borderWidth: 0;
		hResizing: #rigid;
		vResizing: #rigid;
		layoutInset: 0.
	transform hasSubmorphs ifTrue: [transform addMorphBack: self separator].
	transform addMorphBack: aMorph.
