grabFromScreen: evt
	"Allow the user to grab a picture from the screen OUTSIDE THE PAINTING AREA and install it in a blank stamp.  To get a stamp in the painting area, click on the stamp tool in a blank stamp."

	| stampButton form |
	"scroll to blank stamp"
	stampButton _ stampHolder stampButtons first.
	[(stampHolder stampFormFor: stampButton) == nil] whileFalse: [stampHolder scroll: 1].
	form _ Form fromUser.
	tool state: #off.
	tool _ stampHolder otherButtonFor: stampButton.
	stampHolder stampForm: form for: tool.	"install it"
	stampButton state: #on.
	stampButton doButtonAction: evt.
	evt hand showTemporaryCursor: (focusMorph getCursorFor: evt).
