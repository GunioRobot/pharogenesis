fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = 'mid') | (suffix = '*') 
		ifTrue: [ self services]
		ifFalse: [#()]
