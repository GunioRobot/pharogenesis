createSyntaxMorph

	| methodNode rootMorph |
	methodNode _ self selectedClass compilerClass new
			parse: contents
			in: self selectedClass
			notifying: nil.
	(rootMorph _ methodNode asMorphicSyntaxUsing: SyntaxMorph)
		parsedInClass: self selectedClass;
		debugger: self.
	self addDependent: rootMorph.
	^rootMorph

