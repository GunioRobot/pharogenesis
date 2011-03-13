addTab: aStringOrMorph
	"Add a new tab with the given text."
	
	self
		addMorphBack: (self newLabelMorph: aStringOrMorph);
		adoptPaneColor: self paneColor