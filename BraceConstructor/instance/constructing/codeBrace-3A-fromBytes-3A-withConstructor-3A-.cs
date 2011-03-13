codeBrace: numElements fromBytes: aDecompiler withConstructor: aConstructor
	"Decompile.  Consume at least a Pop and usually several stores into variables
	 or braces.  See BraceNode<formBrace for details."

	decompiler _ aDecompiler.
	constructor _ aConstructor.
	elements _ Array new: (initIndex _ numElements).
	[decompiler interpretNextInstructionFor: self.
	 initIndex = 0]
		whileFalse: [].
	^constructor codeBrace: elements