findFirst: aBlock
	"Answer the next object that satisfies aBlock, skipping any intermediate objects.
	If no object is found, answer <nil>.
	NOTA BENE:  aBlock MUST NOT contain a non-local return (^)."

	| value readPos |
	accessProtect critical: [
		value := nil.
		readPos := readPosition.
		[readPos < writePosition
			and: [value isNil]]
			whileTrue: [
				value := contentsArray at: readPos.
				readPos := readPos + 1.
				(aBlock value: value)
					ifFalse: [value := nil]].
		readPosition >= writePosition ifTrue: [readSynch initSignals].
	].
	^value