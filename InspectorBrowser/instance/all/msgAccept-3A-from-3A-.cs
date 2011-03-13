msgAccept: newText from: editor
	| category |
	category _ msgListIndex = 0
		ifTrue: ['as yet unclassified']
		ifFalse: [object class organization categoryOfElement: (msgList at: msgListIndex)].
	^ (object class compile: newText classified: category notifying: editor) ~~ nil