quitSqueak

	(self confirm: 'REALLY quit Squeak?') ifFalse: [^self].
	Smalltalk snapshot: false andQuit: true.