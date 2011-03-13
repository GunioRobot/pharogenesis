selectedMessage
	"Answer the source code of the currently selected context."

	contents == nil ifTrue: [contents _ self selectedContext sourceCode].
	^contents