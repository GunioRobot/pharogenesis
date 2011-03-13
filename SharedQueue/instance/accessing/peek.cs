peek
	"Answer the object that was sent through the receiver first and has not 
	yet been received by anyone but do not remove it from the receiver. If 
	no object has been sent, return nil"

	| value |
	accessProtect
		critical: [readPosition >= writePosition
					ifTrue: [readPosition := 1.
							writePosition := 1.
							value := nil]
					ifFalse: [value := contentsArray at: readPosition]].
	^value