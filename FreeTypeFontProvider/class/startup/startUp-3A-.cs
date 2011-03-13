startUp: resuming
	(Preferences UpdateFontsAtImageStartup and: [resuming])
		ifTrue:[
			self current updateFromSystem]