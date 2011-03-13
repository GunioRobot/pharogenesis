rootPanel
	"Answer a new root panel for the main contents of the browser."
	
	^UITheme builder newPanel
		addMorphBack: self newSearchPanel;
		addMorphBack: self mainPanel;
		yourself