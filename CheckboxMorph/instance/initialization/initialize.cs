initialize
	"Initialize the receiver."

	super initialize.
	self
		borderWidth: 2; "space for focus"
		borderColor: Color transparent;
		enabled: true;
		changeTableLayout;
		listDirection: #leftToRight;
		wrapCentering: #center;
		cellInset: 8;
		buttonMorph: self newButtonMorph;
		labelMorph: self newLabelMorph;
		on: #mouseDown send: #updateButton: to: self;
		on: #mouseMove send: #updateButton: to: self;
		on: #mouseUp send: #updateButton: to: self