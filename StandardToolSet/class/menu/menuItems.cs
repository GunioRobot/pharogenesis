menuItems
	"Answer the menu items available for this tool set"
	^#(
		('Class Browser' 			#openClassBrowser)
		('Message Names'				#openMessageNames)
		('Method Finder'				#openMethodFinder)
		-
		('Workspace'					#openWorkspace)
		('Transcript' 				#openTranscript)
		('File Browser'				#openFileList)
		-
		('Test Runner'				#openTestRunner)
		('Process Browser' 			#openProcessBrowser)
		-
		('Monticello Browser'		#openMonticelloBrowser)
		"('Monticello Configurations' #openMonticelloConfigurations)"
		('Recover lost changes...'	#openRecentChangesLog)
		"('Simple Change Sorter'		#openChangeSorter)"
		('Change Sorter'				#openDualChangeSorter)
	)
