flushAllSuchThat: aBlock
	"Remove from the queue all objects that satisfy aBlock."
	| value newReadPos |
	accessProtect critical: [
		newReadPos := writePosition.
		writePosition-1 to: readPosition by: -1 do:
			[:i | value := contentsArray at: i.
			contentsArray at: i put: nil.
			(aBlock value: value) ifTrue: [
				"We take an element out of the queue, and therefore, we need to decrement 
				the readSynch signals"
				readSynch wait.
			] ifFalse: [
				newReadPos := newReadPos - 1.
				contentsArray at: newReadPos put: value]].
		readPosition := newReadPos].
	^value
