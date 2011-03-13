nextOrNil
	"Answer the object that was sent through the receiver first and has not 
	yet been received by anyone. If no object has been sent, answer <nil>."

	| value |

	accessProtect critical: [
		readPosition >= writePosition ifTrue: [
			value _ nil
		] ifFalse: [
			value _ contentsArray at: readPosition.
			contentsArray at: readPosition put: nil.
			readPosition _ readPosition + 1
		].
		readPosition >= writePosition ifTrue: [readSynch initSignals].
	].
	^value