createButtonLabel: aString action: actionSelector help: helpString 
	"private - create a button for the receiver"
	| button |
	button := SimpleButtonMorph new target: self;
				 label: aString translated;
				 actionSelector: actionSelector;
				 setBalloonText: helpString translated;
				 borderWidth: 2;
				 useSquareCorners.
	""
	^ button