yesText: aStringOrText help: helpString
	"Set the yes button label."

	self yesButton
		hResizing: #shrinkWrap;
		label: aStringOrText;
		setBalloonText: helpString