publishedVersion
	^self isPublished ifTrue: [self lastPublishedRelease version]