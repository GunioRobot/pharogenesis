initializeWithModel: aPreferenceBrowser
	lastKeystrokeTime := 0.
	lastKeystrokes := ''.
	self 
		model: aPreferenceBrowser;
		clipSubmorphs: true;
		setLabel: self model windowTitle;
		name: 'PreferenceBrowser';
		addMorph: self rootPanel fullFrame: self rootPanelLayoutFrame;
		addMorph: self newButtonRow fullFrame: self buttonRowLayoutFrame.