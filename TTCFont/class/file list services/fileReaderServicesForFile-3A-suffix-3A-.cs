fileReaderServicesForFile: fullName suffix: suffix 
	^(suffix = 'ttf')  | (suffix = '*') 
		ifTrue: [ self services ]
		ifFalse: [ #() ]