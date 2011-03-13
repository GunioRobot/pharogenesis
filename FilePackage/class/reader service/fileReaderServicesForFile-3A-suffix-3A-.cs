fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = 'st') | (suffix = 'cs') | (suffix = '*')
		ifTrue: [self services]
		ifFalse: [#()]