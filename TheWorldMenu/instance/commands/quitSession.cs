quitSession

	SmalltalkImage current
		snapshot: (self confirm: 'Save changes before quitting?' translated orCancel: [^ self])
		andQuit: true