getModelState
	"Answer the result of sending the receiver's model the getStateSelector message."

	getStateSelector == nil
		ifTrue: [^ false]
		ifFalse: [^ model perform: getStateSelector].
