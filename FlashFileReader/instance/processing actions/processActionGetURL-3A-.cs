processActionGetURL: data
	| length position urlString winString |
	length _ data nextWord.
	position _ data position.
	urlString _ data nextString.
	winString _ data nextString.
	data position = (position + length) ifFalse:[
		self halt.
		data position: position.
		^self processUnknownAction: data].
	log ifNotNil:[
		log 
			nextPutAll:' url='; print: urlString;
			nextPutAll:', win='; print: winString].
	^Message selector: #getURL:window: arguments: (Array with: urlString with: winString)