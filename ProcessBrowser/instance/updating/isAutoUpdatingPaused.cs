isAutoUpdatingPaused
	^autoUpdateProcess notNil and: [ autoUpdateProcess isSuspended ]