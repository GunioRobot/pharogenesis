myServicesForFile: fullName suffix: suffix

	^(FileStream isSourceFileSuffix: suffix)
		ifTrue: [ {self serviceBroadcastUpdate} ]
		ifFalse: [ #() ]