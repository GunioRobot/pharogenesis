fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = '3ds') | (suffix = '*') 
		ifTrue: [Array with: self serviceOpen3DSFile]
		ifFalse: [#()]
