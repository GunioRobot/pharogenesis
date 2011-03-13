allowEtoyUserCustomEvents
	^ self
		valueOfFlag: #allowEtoyUserCustomEvents
		ifAbsent: [false]