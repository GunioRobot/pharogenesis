pathName: p isEncoded: isEncoded

	converter _ LanguageEnvironment defaultFileNameConverter.
	isEncoded ifTrue: [
		squeakPathName _ p convertFromWithConverter: converter.
		vmPathName _ p.
	] ifFalse: [
		squeakPathName _ p isOctetString ifTrue: [p asOctetString] ifFalse: [p].
		vmPathName _ squeakPathName convertToWithConverter: converter.
	].
