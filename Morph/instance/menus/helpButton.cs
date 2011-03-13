helpButton
	"Answer a button whose action would be to put up help concerning the receiver"

	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton
		target: self;
		color: ColorTheme current helpColor;
		borderColor: ColorTheme current helpColor muchDarker;
		borderWidth: 1;
		label: '?' translated font: Preferences standardButtonFont;
		actionSelector: #presentHelp;
		setBalloonText: 'click here for help' translated.
	^ aButton