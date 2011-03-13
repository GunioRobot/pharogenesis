initialize

	super initialize.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self layoutInset: 3.
	color _ Color veryLightGray.
	self borderWidth: 2.
	self onScorePlayer: (ScorePlayer new initialize) title: ' '.
	self extent: 20@20.
