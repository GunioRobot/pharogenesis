enableLocalSave
	^ self
		valueOfFlag: #enableLocalSave
		ifAbsent: [true]