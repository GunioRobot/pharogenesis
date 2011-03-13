doneApplyingChanges
	| comment |
	comment := UIManager default
		multiLineRequest: 'Comment for this update.'
		centerAt: Sensor cursorPoint
		initialAnswer: self commentForCurrentUpdate
		answerHeight: 200.
	comment ifNil: [^ self].
	self class
		compile: ('commentForCurrentUpdate', String cr, '	^''' , comment, '''')
		classified: 'public'.
	
	self class waitingCacheFolder deleteLocalFiles.
	self saveChangedPackagesIntoWaitingFolder.
	self generateScriptAndUpdateMethodForNewVersion.
	self saveLatestScriptLoaderToWaitingFolder.
	
	self inform: 'Update prepared and ready to be verified.'