availablePlugins
	allPlugins ifNil:[self initializeAllPlugins].
	^allPlugins