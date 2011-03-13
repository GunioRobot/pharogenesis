nextWindow
	^ ServiceAction text: 'Switch to next window' button: 'next window' description: 'Switches to the next window' action: [:r | SystemWindow sendTopWindowToBack]