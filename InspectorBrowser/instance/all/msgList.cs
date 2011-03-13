msgList
	msgList ifNotNil: [^ msgList].
	^ (msgList _ object class selectors asSortedCollection asArray)