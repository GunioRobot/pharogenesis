flushAllSuchThat: aBlock
	"Remove from the queue all objects that satisfy aBlock."
	| value newReadPos |
	accessProtect critical: [
		newReadPos _ writePosition.
		writePosition-1 to: readPosition by: -1 do:
			[:i | value _ contentsArray at: i.
			contentsArray at: i put: nil.
			(aBlock value: value) ifTrue: [
				"We take an element out of the queue, and therefore, we need to decrement 
				the readSynch signals"
				readSynch wait.
			] ifFalse: [
				newReadPos _ newReadPos - 1.
				contentsArray at: newReadPos put: value]].
		readPosition _ newReadPos].
	^value
