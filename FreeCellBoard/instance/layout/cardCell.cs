cardCell

	^PlayingCardDeck new
		layout: #pile; 
		orientation: #vertical;
		enableDragNDrop;
		color: Color transparent;
		borderColor: (Color gray alpha: 0.5);
		borderWidth: 2;
		yourself