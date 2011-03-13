initializeSlider
	self roundedScrollbarLook ifTrue:[
		self 
			initializeUpButton;
			initializeDownButton;
			initializePagingArea.
	] ifFalse:[
		self initializeUpButton; 
			initializeDownButton; 
			initializePagingArea.
	].
	super initializeSlider.
	self roundedScrollbarLook ifTrue:[
		slider cornerStyle: #rounded.
		slider borderStyle: (BorderStyle complexRaised width: 3).
		sliderShadow cornerStyle: #rounded.
	].
	self sliderColor: self sliderColor.