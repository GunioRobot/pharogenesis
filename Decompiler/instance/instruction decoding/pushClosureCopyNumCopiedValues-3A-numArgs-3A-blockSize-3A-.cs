pushClosureCopyNumCopiedValues: numCopied numArgs: numArgs blockSize: blockSize
	| copiedValues |
	self sawClosureBytecode.
	numCopied > 0
		ifTrue:
			[copiedValues := Array new: numCopied.
			 numLocalTemps == #decompileBlock: ifTrue: "Hack fake temps for copied values"
				[1 to: numCopied do: [:i| stack addLast: (constructor codeTemp: i - 1)]].
			 numCopied to: 1 by: -1 do:
				[:i|
				copiedValues at: i put: stack removeLast]]
		ifFalse:
			[copiedValues := #()].
	self doClosureCopyCopiedValues: copiedValues numArgs: numArgs blockSize: blockSize