processFilesForInternalPlugin: plugin 
	"See comment in VMMaker>processFileForInternalPlugin: first.
	When using a copying version of VMMaker, copy any files relating to the internal plugin from the crossPlatform & platformDirectory subdir 'plugins'"

	super processFilesForInternalPlugin: plugin.

	"This version of the method has to actually copy files around"
	self copyCrossPlatformFilesFor: plugin internal: true;
		copyPlatformFilesFor: plugin internal: true