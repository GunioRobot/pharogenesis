fileReaderServicesForFile: fullName suffix: suffix 

	^((MPEGPlayer registeredVideoFileSuffixes includes: suffix )
		or: [ (MPEGPlayer registeredAudioFileSuffixes includes: suffix)
			or: [ suffix = '*' ]] )
		ifTrue: [ self services ]
		ifFalse: [ #() ]