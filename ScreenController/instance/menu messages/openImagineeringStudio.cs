openImagineeringStudio
	(Smalltalk includesKey: #EToySystem) ifFalse:
		[^ self inform: 'Sorry, this system does not support EToys'].
	(Smalltalk at: #EToySystem) openImagineeringStudio