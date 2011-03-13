initialize
"initialize the state of the receiver"
	super initialize.
	""
	self hResizing: #shrinkWrap;
		 vResizing: #shrinkWrap.
	borderWidth := 2.
	self listDirection: #topToBottom.
	self cornerStyle: #rounded.
	self layoutInset: 4.
	moviePlayer := MPEGDisplayMorph new.
	self addMorphFront: moviePlayer.
	self addButtonRow.
	self addVolumeSlider.
	self addPositionSlider.
	self extent: 10 @ 10