getModelState
	"Answer the result of sending the receiver's model the getStateSelector message."

	^ getStateSelector isNil 
		ifTrue: [false]
		ifFalse: [model perform: getStateSelector]