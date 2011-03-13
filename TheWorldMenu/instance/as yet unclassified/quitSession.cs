quitSession

	Smalltalk
		snapshot: (self confirm: 'Save changes before quitting?' orCancel: [^ self])
		andQuit: true