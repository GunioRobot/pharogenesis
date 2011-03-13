buildInstanceSwitchView

	| aSwitchView |
	aSwitchView _ PluggableButtonView
		on: self
		getState: #instanceMessagesIndicated
		action: #indicateInstanceMessages.
	aSwitchView
		label: 'instance';
		borderWidthLeft: 0 right: 1 top: 0 bottom: 0;	
		window: (0@0 extent: 25@8);
		askBeforeChanging: true.
	^ aSwitchView
