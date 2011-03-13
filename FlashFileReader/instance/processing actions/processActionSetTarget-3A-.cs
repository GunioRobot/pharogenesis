processActionSetTarget: data
	| length target |
	length := data nextWord.
	target := data nextString.
	log ifNotNil:[log nextPutAll:' target = '; print: target].
	^Message selector: #actionTarget: argument: target.