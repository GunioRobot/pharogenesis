primitiveResolverStartNameLookup

	| name sz |
	name _ self stackTop.
	self successIfClassOf: name is: (self splObj: ClassString).
	successFlag ifTrue: [
		sz _ self lengthOf: name.
		self sqResolverStartName: (self cCoerce: (name + BaseHeaderSize) to: 'char *')
			Lookup: sz.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop name, leave rcvr on stack"
	].
