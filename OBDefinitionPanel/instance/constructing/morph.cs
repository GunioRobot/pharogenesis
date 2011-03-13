morph
	^ (OBPluggableTextMorph
		on: self
		text: #text
		accept: #accept:notifying:
		readSelection: #selection
		menu: #menu:shifted:)
			font: Preferences standardCodeFont;
			yourself
			
	"see CodeHolder>>buildMorphicCodePaneWith:"