deleteUnwantedInternalPluginDirectories
	"delete directories in the internal plugins tree with names not in the list  
	of internal plugins. This will make sure that only wanted plugins are  
	left after generating internal plugins - no previous ones will get left  
	there like unwanted porridge"
	(self internalPluginsDirectory directoryNames copyWithoutAll: self internalModuleNames)
		do: [:nm | (self internalPluginsDirectory directoryNamed: nm) recursiveDelete]