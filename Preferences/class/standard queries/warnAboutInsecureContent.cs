warnAboutInsecureContent
	^ self
		valueOfFlag: #warnAboutInsecureContent
		ifAbsent: [true]