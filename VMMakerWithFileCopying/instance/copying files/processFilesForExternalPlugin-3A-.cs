processFilesForExternalPlugin: plugin 
	"See comment in VMMaker>processFileForExternalPlugin: first.
	When using a copying version of VMMaker, copy any files relating to the external plugin from the crossPlatform & platformDirectory subdir 'plugins'"

	super processFilesForExternalPlugin: plugin.

	"This version of the method has to actually copy files around"
	self copyCrossPlatformFilesFor: plugin internal: false;
		copyPlatformFilesFor: plugin internal: false