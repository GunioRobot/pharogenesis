storeInternalPluginList
	| s fileName |
	fileName _ self makefileDirectory fullNameFor: 'plugins.int'.
	[s _ CrLfFileStream forceNewFileNamed: fileName] 
		on: FileDoesNotExistException 
		do:[^self couldNotOpenFile: fileName].
	s nextPutAll:'# Automatically generated makefile include for internal plugins'.
	s cr; nextPutAll:'INTERNAL_PLUGINS ='.
	self internalPluginsDo:[:cls|
		s space; nextPutAll: cls moduleName.
	].
	s cr; close