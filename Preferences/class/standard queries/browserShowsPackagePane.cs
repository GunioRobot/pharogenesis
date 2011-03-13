browserShowsPackagePane
	^ self
		valueOfFlag: #browserShowsPackagePane
		ifAbsent: [false]