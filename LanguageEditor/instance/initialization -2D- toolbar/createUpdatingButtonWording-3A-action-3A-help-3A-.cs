createUpdatingButtonWording: wordingSelector action: actionSelector help: helpString 
	"create a toolbar for the receiver"
	| button |
	button := (UpdatingSimpleButtonMorph newWithLabel: '-') target: self;
				 wordingSelector: wordingSelector;
				 actionSelector: actionSelector;
				 setBalloonText: helpString translated;
				 color: translator defaultBackgroundColor twiceDarker;
				 borderWidth: 1;
				 borderColor: #raised; cornerStyle: #square.
	""
	^ button