initialize

	super initialize.
	orientation _ #vertical.
	centering _ #center.
	hResizing _ #spaceFill.
	vResizing _ #spaceFill.
	inset _ 3.
	color _ Color veryLightGray.
	self borderWidth: 2.
	self onScorePlayer: (ScorePlayer new initialize) title: ' '.
	self extent: 20@20.
