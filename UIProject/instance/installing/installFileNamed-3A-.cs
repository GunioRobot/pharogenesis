installFileNamed: filename
	FileDirectory splitName: filename to: [ :path :base |
		[ 	
			ProjectViewMorph openFromDirectory: (FileDirectory on: path) andFileName: base
		] on: ProjectEntryNotification do:
		[ :ex |
			"don't enter it" ] ]