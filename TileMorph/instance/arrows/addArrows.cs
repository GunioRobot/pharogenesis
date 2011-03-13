addArrows
	| frame |
	downArrow _ ImageMorph new image: DownPicture.
	upArrow _ ImageMorph new image: UpPicture.
	frame _ Morph new color: Color transparent.
	frame 
		layoutPolicy: TableLayout new;
		listDirection: #topToBottom;
		hResizing: #shrinkWrap; 
		vResizing: #shrinkWrap;
		cellInset: 0@1;
		layoutInset: 0@1.
	frame addMorphBack: upArrow; addMorphBack: downArrow.
	self addMorphFront: frame.
