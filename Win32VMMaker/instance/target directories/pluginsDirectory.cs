pluginsDirectory
	"return the target directory for the plugins sources - for Windows this is the platforms source directory for the plugin"
	| fd |
	fd _ self sourceDirectory directoryNamed: self class pluginsDirName.
	fd assureExistence.
	^fd