fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = 'movie') | (suffix = '*')
		ifTrue: [ self services]
		ifFalse: [#()]