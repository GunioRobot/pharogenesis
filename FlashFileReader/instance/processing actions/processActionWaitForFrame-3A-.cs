processActionWaitForFrame: data
	| length frame skip |
	length := data nextWord.
	length = 3 ifFalse:["Something is wrong"
		data skip: -2.
		^self processUnknownAction: data].
	frame := data nextWord.
	skip := data nextByte.
	log ifNotNil:[
		log nextPutAll:'frame = '; print: frame;
			nextPutAll:', skip = '; print: skip].
	^Message selector: #isFrameLoaded:elseSkip: arguments: (Array with: frame with: skip).