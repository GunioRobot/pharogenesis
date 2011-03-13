msgList
	msgList ifNotNil: [^ msgList].
	^ (msgList := object class selectors asSortedArray)