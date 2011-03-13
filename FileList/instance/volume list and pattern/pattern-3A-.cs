pattern: textOrStringOrNil

	textOrStringOrNil
		ifNil: [pattern _ '*']
		ifNotNil: [pattern _ textOrStringOrNil asString].
	self updateFileList.
	^ true
