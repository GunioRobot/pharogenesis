processActionGotoFrame: data
	| length frame |
	length _ data nextWord.
	length = 2 ifFalse:["There is something wrong here"
		self halt.
		data skip: -2.
		^self processUnknownAction: data].
	frame _ data nextWord.
	log ifNotNil:[log nextPutAll:' frame = '; print: frame.].
	^Message selector: #gotoFrame: argument: frame