showByteCodes: aBoolean
	"Get into or out of bytecode-showoing mode"

	self okToChange ifFalse: [^ self changed: #flash].
	aBoolean
		ifTrue:
			[contentsSymbol _ #byteCodes]
		ifFalse:
			[contentsSymbol == #byteCodes ifTrue: [contentsSymbol _ #source]].
	self contentsChanged