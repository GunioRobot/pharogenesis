useLocale
	^ self
		valueOfFlag: #useLocale
		ifAbsent: [false]