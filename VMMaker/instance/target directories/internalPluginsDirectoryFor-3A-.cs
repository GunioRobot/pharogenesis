internalPluginsDirectoryFor: plugin
	"return the directory for the internal plugin sources"
	|fd|
	fd _ self internalPluginsDirectory directoryNamed: plugin moduleName.
	fd assureExistence.
	^fd