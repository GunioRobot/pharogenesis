externalPluginsDirectoryFor: plugin
	"return the directory for the external plugin sources"
	|fd|
	fd _ self externalPluginsDirectory directoryNamed: plugin moduleName.
	fd assureExistence.
	^fd