initializeWithModel: aFontChooser
	self 
		model: aFontChooser;
		clipSubmorphs: true;
		setLabel: self model windowTitle;
		name: 'FontChooser'.
	self updatePreview