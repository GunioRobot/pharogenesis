mouseDown: evt
	evt yellowButtonPressed ifTrue: [
		self yellowButtonMenu.
		^super mouseDown: evt].