toggleAlwaysShowThumbnail
	(self hasProperty: #alwaysShowThumbnail)
		ifTrue:
			[self removeProperty: #alwaysShowThumbnail]
		ifFalse:
			[self setProperty: #alwaysShowThumbnail toValue: true].
	self updateSubmorphThumbnails