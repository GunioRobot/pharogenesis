initializeForms
	"Initialize the receiver's image forms."

	super initializeForms.
	self forms
		at: #windowCloseDown put: self newWindowCloseDownForm;
		at: #windowMinimizeDown put: self newWindowMinimizeDownForm;
		at: #windowMaximizeDown put: self newWindowMaximizeDownForm;
		at: #dropListDownArrow put: self newDropListDownArrowForm