configurationInfo
	"build a simple Array of the configuration information that would be 
	usefully saved for later reloading:- 
	the list of internal & external plugins, the flags, the platform name, and the two major directory names"
	^ Array new writeStream nextPut: internalPlugins;
		 nextPut: externalPlugins;
		 nextPut: inline;
		 nextPut: forBrowser;
		 nextPut: platformName;
		 nextPut: self sourceDirectory pathName;
		 nextPut: self platformRootDirectory pathName;
	contents