processActionWaitForFrame: data
	| length frame skip |
	length _ data nextWord.
	length = 3 ifFalse:["Something is wrong"
		data skip: -2.
		^self processUnknownAction: data].
	frame _ data nextWord.
	skip _ data nextByte.
	log ifNotNil:[
		log nextPutAll:'frame = '; print: frame;
			nextPutAll:', skip = '; print: skip].
	^Message selector: #isFrameLoaded:elseSkip: arguments: (Array with: frame with: skip).