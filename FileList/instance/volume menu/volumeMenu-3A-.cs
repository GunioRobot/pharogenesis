volumeMenu: aMenu
	aMenu addList: {
			{'recent...' translated.		#recentDirs}.
			#-.
			{'add server...' translated.		#askServerInfo}.
			{'remove server...' translated.		#removeServer}.
			#-.
			{'delete directory...' translated.	#deleteDirectory}.
			#-}.
	aMenu
		addServices: (self itemsForDirectory: self directory)
		for: self
		extraLines: #().
	^aMenu.