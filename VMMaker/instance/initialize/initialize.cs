initialize
	logger := Transcript.
	inline _ true.
	forBrowser _ false.
	internalPlugins _ SortedCollection new.
	externalPlugins _ SortedCollection new.
	platformName _ self class machinesDirName.
	allFilesList _ Dictionary new.
	interpreterClassName _ 'Interpreter'.