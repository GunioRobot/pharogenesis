makeViews: cache for: aSwitch

	| form aSwitchView |
	form := cache form.
	aSwitchView := PluggableButtonView
		on: aSwitch
		getState: #isOn
		action: #switch.
	aSwitchView
		label: form;
		shortcutCharacter: cache value;
		window: (0@0 extent: form extent);
		translateBy: cache offset;
		borderWidth: 1.
	self addSubView: aSwitchView.
	^ aSwitchView
