messageList 
	| thisClass |
	(thisClass := self selectedClassOrMetaClass) ifNil: [^ #() ] .
	^self basicMessageList collect: [ :each |
		each asString , (self packageNoteForClass: thisClass selector: each) ] .
