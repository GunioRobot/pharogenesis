fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = 'swf') | (suffix = '*') 
		ifTrue: [ self services]
		ifFalse: [#()]
