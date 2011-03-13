basicButton
	"Answer an initialised button for use in the button row."
	
	^(UITheme builder
		newButtonFor: self model
		action: nil
		label: ''
		help: nil)
		vResizing: #spaceFill;
		hResizing: #shrinkWrap