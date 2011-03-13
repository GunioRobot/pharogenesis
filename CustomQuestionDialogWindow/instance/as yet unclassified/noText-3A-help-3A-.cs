noText: aStringOrText help: helpString
	"Set the no button label."

	self noButton
		hResizing: #shrinkWrap;
		label: aStringOrText;
		setBalloonText: helpString