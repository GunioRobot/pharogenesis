pageControls: evt

	| buttonPanel |
	buttonPanel _ self makePageControls.
	buttonPanel borderWidth: 1; inset: 4.
	evt hand attachMorph: buttonPanel.
