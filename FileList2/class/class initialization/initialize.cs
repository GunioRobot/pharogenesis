initialize
	Preferences
		addPreference: #useFileList2
		categories:  #(general)
		default: true
		balloonHelp: 'if true, then when you open a file list from the World menu, it''ll be an enhanced one'
		projectLocal:  false
		changeInformee:  self
		changeSelector: #useFileList2preferenceChanged