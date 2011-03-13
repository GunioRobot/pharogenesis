initializeWithModel: aPreferenceBrowser
	"Initialize the receiver based on the given model."
	
	|buttonRow|
	lastKeystrokeTime := 0.
	lastKeystrokes := ''.
	self model: aPreferenceBrowser.
	buttonRow := self newButtonRow.
	self 
		clipSubmorphs: true;
		setLabel: self model windowTitle;
		name: 'PreferenceBrowser';
		addMorph: self rootPanel
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1@1) offsets: (0@(buttonRow minExtent y) corner: 0@0));
		addMorph: buttonRow
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1@0) offsets: (0@0 corner: 0@ buttonRow minExtent y))