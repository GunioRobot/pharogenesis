recordDefineButton: id
	"Record the definition of a new button with the given id"
	| button |
	button _ buttons at: id put: FlashButtonMorph new.
	button id: id.
	shapes at: id put: button.