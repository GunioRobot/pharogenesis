dismissButton
	"Answer a button whose action would be to dismiss the receiver, and whose action is to send #delete to the receiver"

	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton
		target: self topRendererOrSelf;
		color:  Color tan;
		label: 'X' font: Preferences standardButtonFont;
		actionSelector: #delete;
		setBalloonText: 'dismiss' translated.
	^ aButton