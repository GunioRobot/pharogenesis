selectedTranslationsAt: index put: value 
	value = true
		ifTrue: [selectedTranslations add: index]
		ifFalse: [selectedTranslations
				remove: index
				ifAbsent: []]