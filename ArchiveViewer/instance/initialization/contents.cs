contents
	| contents errorMessage |
	self selectedMember ifNil: [^ ''].
	viewAllContents ifFalse: [^ self briefContents].

 	[ contents := self selectedMember contents ]
		on: CRCError
		do: [ :ex | errorMessage := String streamContents: [ :stream |
			stream nextPutAll: '********** WARNING! Member is corrupt! [ ';
			nextPutAll: (ex messageText copyUpToLast: $( );
			nextPutAll: '] **********'; cr ].
			ex proceed ].

	^self selectedMember isCorrupt
		ifFalse: [ contents ]
		ifTrue: [ errorMessage, contents ]