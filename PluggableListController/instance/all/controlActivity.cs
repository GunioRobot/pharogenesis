controlActivity
	"Overridden to handle keystrokes."

	sensor keyboardPressed ifTrue: [view handleKeystroke: sensor keyboard].
	super controlActivity.