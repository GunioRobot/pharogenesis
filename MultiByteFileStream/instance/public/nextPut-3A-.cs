nextPut: aCharacter

	aCharacter isInteger ifTrue: [^ super nextPut: aCharacter].
	self doConversion ifTrue: [
		aCharacter = Cr ifTrue: [
			(LineEndStrings at: lineEndConvention) do: [:e | converter nextPut: e toStream: self].
		] ifFalse: [
			converter nextPut: aCharacter toStream: self
		].
		^ aCharacter
	].
	^ self converter nextPut: aCharacter toStream: self
