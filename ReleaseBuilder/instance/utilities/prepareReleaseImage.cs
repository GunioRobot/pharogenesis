prepareReleaseImage
	"Perform various image cleanups in preparation for making a Squeak gamma release candidate image."
	"ReleaseBuilder new prepareReleaseImage"
	
	(self confirm: 'Are you sure you want to prepare a release image?
This will perform several irreversible cleanups on this image.')
		ifFalse: [^ self].

	self
		initialCleanup;
		installPreferences;
		finalStripping;
		installReleaseSpecifics;
		finalCleanup;
		installVersionInfo
