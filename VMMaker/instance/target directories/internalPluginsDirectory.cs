internalPluginsDirectory
	"return the directory for the internal plugins sources"
	|fd|
	fd _ self coreVMDirectory directoryNamed: 'intplugins'.
	fd assureExistence.
	^fd