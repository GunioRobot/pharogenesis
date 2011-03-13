allLiterals
	((literalStream isKindOf: WriteStream)
	 and: [ (addedSelectorAndMethodClassLiterals ifNil: [ false ]) not]) ifTrue:
		[addedSelectorAndMethodClassLiterals := true.
		 self litIndex: nil.
		 self litIndex: self associationForClass].
	^literalStream contents

	"The funky ifNil: [false], even though the init method initializes addedSAMCL,
	 is simply so that Monticello can load and compile this update without
	 killing the encoder that is compiling that update itself..."