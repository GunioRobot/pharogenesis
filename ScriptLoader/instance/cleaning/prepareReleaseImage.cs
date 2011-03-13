prepareReleaseImage
	"Perform various image cleanups in preparation for making a Squeak gamma release candidate image."
	"self new prepareReleaseImage"
	
	(self confirm: 'Are you sure you want to prepare a release image?
This will perform several irreversible cleanups on this image.')
		ifFalse: [^ self].

	self
		"unloadPackages;"
		initialCleanup;
		installPreferences;
		finalStripping;
		finalCleanup
		"installVersionInfo"
