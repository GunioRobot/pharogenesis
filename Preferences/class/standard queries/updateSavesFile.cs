updateSavesFile
	^ self
		valueOfFlag: #updateSavesFile
		ifAbsent: [false]