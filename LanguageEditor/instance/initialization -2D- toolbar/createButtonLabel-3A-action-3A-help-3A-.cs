createButtonLabel: aString action: actionSelector help: helpString 
	"create a toolbar for the receiver"
	| button |
	button := SimpleButtonMorph new target: self;
				 label: aString translated "font: Preferences standardButtonFont";
				 actionSelector: actionSelector;
				 setBalloonText: helpString translated;
				 color: translator defaultBackgroundColor twiceDarker;
				 borderWidth: 2;
				 borderColor: #raised.
	""
	^ button