artistList

	((musicTypeIndex ~= nil) and:
	 [musicTypeIndex between: 1 and: artistList size])
		ifTrue: [^ artistList at: musicTypeIndex]
		ifFalse: [^ #()].
