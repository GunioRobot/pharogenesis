processYellowButton
	"Suppress yellow-button menu if acceptOnCR is true."

	model acceptOnCR ifFalse: [^ super processYellowButton].
