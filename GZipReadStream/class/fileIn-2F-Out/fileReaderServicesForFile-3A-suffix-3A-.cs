fileReaderServicesForFile: fullName suffix: suffix 
	| services |
	(suffix = 'gz') | (suffix = '*')
		ifFalse: [^ #()].
	services _ OrderedCollection new.
	(suffix = '*') | (fullName asLowercase endsWith: '.cs.gz') | (fullName asLowercase endsWith: '.mcs.gz')
		ifTrue: [services add: self serviceFileIn.
			(Smalltalk includesKey: #ChangeSorter)
				ifTrue: [services add: self serviceFileIntoNewChangeSet]].
	services addAll: self services.
	^ services