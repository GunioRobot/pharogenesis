fileReaderServicesForFile: fullName suffix: suffix

	^ (suffix = 'kkk')
		ifTrue: [ self services]
		ifFalse: [#()] 