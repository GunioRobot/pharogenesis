buildCommentSwitchView

	| aSwitchView |
	aSwitchView := PluggableButtonView
		on: self
		getState: #classCommentIndicated
		action: #plusButtonHit.
	aSwitchView
		label: '?' asText allBold;
		borderWidthLeft: 0 right: 1 top: 0 bottom: 0;	
		window: (0@0 extent: 10@8);
		askBeforeChanging: true.
	^ aSwitchView
