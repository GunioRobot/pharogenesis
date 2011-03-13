processActionGotoFrame: data
	| length frame |
	length := data nextWord.
	length = 2 ifFalse:["There is something wrong here"
		self halt.
		data skip: -2.
		^self processUnknownAction: data].
	frame := data nextWord.
	log ifNotNil:[log nextPutAll:' frame = '; print: frame.].
	^Message selector: #gotoFrame: argument: frame