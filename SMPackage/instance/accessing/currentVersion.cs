currentVersion
	^self isPublished ifTrue: [self lastPublishedRelease version]