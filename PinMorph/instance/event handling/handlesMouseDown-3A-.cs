handlesMouseDown: evt

	^ (evt yellowButtonPressed | evt blueButtonPressed) not
