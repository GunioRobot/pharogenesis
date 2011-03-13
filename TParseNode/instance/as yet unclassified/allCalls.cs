allCalls
	"Answer a collection of selectors for the messages sent in this parse tree."

	| calls |
	calls _ Set new: 100.
	self nodesDo: [ :node |
		node isSend ifTrue: [ calls add: node selector ].
	].
	^calls