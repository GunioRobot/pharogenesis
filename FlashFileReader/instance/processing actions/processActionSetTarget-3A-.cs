processActionSetTarget: data
	| length target |
	length _ data nextWord.
	target _ data nextString.
	log ifNotNil:[log nextPutAll:' target = '; print: target].
	^Message selector: #actionTarget: argument: target.