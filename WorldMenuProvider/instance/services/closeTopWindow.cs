closeTopWindow
	^ ServiceAction
		text: 'Close top window'
		button: 'close window'
		description: 'Closes the focused window'
		action: [:r | SystemWindow topWindow delete]