deleteUnwantedInternalPluginDirectories
	"delete directories in the internal plugins tree with names not in the list  
	of internal plugins. This will make sure that only wanted plugins are  
	left after generating inernal plugins - no previous ones will get left  
	there like unwanted porridge"
	"On windows, we are keeping all the plugins in one place, the platforms tree, so don't delete - we can't easily tell which ones need to be kept"