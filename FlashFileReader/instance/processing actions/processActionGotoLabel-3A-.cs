processActionGotoLabel: data
	| length label |
	length _ data nextWord.
	label _ data nextString.
	log ifNotNil:[log nextPutAll:' label = '; print: label].
	^Message selector: #gotoLabel: argument: label