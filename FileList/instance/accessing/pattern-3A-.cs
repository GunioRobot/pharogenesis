pattern: textOrStringOrNil

	textOrStringOrNil
		ifNil: [pattern := '*']
		ifNotNil: [pattern := textOrStringOrNil asString].
	self updateFileList.
	^ true
