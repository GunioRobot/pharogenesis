buildClassSwitchView

	| aSwitchView |
	aSwitchView _ PluggableButtonView
		on: self
		getState: #classMessagesIndicated
		action: #indicateClassMessages.
	aSwitchView
		label: 'class';
		window: (0@0 extent: 15@8);
		askBeforeChanging: true.
	^ aSwitchView
