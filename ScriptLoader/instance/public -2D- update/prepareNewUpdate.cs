prepareNewUpdate
	self launchUpdate.
	self loadLatestScriptloader.
	self markPackagesBeforeNewCodeIsLoaded.
	self inform: 'Download update.list file using the script ./getUpdatesList and proceed when done'.
	self checkImageIsUptodate ifFalse: [
		^ self inform: 'Your update.list and your image are not in sync! Please use a fresh image and download the latest update.list and start over.' ].
	self setUpdateAndScriptVersionNumbers.
	self saveAsNewImageWithCurrentReleaseName.
	self inform: 'The new version number is ' , self currentUpdateVersionNumber asString , '. Ready to apply changes now.', String cr, 'You are now running in image ', (FileDirectory baseNameFor: (FileDirectory default localNameFor: SmalltalkImage current imageName)).