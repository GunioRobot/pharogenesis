initializeSlider
	"Initialize the receiver's slider."
	
	self roundedScrollbarLook
		ifTrue: [self initializeUpButton; initializeMenuButton; initializeDownButton; initializePagingArea]
		ifFalse: [self initializeMenuButton; initializeUpButton; initializeDownButton; initializePagingArea].
	super initializeSlider.
	self roundedScrollbarLook
		ifTrue: [slider cornerStyle: #rounded.
			slider
				borderStyle: (BorderStyle complexRaised width: 3).
			sliderShadow cornerStyle: #rounded].
	self sliderColor: self sliderColor.
	Preferences gradientScrollbarLook ifFalse: [^self].
	slider cornerStyle: (self theme scrollbarThumbCornerStyleIn: self window).
	slider on: #mouseEnter send: #mouseEnterThumb: to: self.
	slider on: #mouseLeave send: #mouseLeaveThumb: to: self