readFromV1: aStream
	| cr |
	cr _ Character cr.
	^Array streamContents:[:tStream |
		[aStream atEnd] whileFalse:[
			tStream nextPut: (MorphicEvent readFromString: (aStream upTo: cr))]]