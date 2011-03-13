processActionGotoLabel: data
	| length label |
	length := data nextWord.
	label := data nextString.
	log ifNotNil:[log nextPutAll:' label = '; print: label].
	^Message selector: #gotoLabel: argument: label