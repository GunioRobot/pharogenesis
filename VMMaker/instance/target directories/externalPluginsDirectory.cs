externalPluginsDirectory
	"return the target directory for the external plugins sources"
	| fd |
	fd _ self sourceDirectory directoryNamed: self class pluginsDirName.
	fd assureExistence.
	^fd