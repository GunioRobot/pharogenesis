installer
	^ Smalltalk 
		at: #Installer
		ifAbsent: 
			[ self installingInstaller.
			Smalltalk at: #Installer ]