initialize
	"Initialize the receiver."
	
	Preferences
		addPreference: #keepTasklistOpen
		categories: #(windows)
		default: false
		balloonHelp: 'Whether the tasklist is closed (and the selected window activated) when the command key is released'