loadConfiguration: aConfigArray
	"load the configuration but ignore the platformName - the platform name must have been handled during the creation of this vmmaker in order for it to work correctly"

	inline _ aConfigArray at:3.
	forBrowser _ aConfigArray at: 4.
	"This part must be ignored --> self setPlatName: (aConfigArray at: 5)."
	self sourceDirectoryName: (aConfigArray at: 6).
	self platformRootDirectoryName: ( aConfigArray at:7).
	self initializeAllPlugins.
	self internal: (aConfigArray at:1) external:(aConfigArray at:2).
	self changed: #reinitialize 