changeClassOf: anObject to: aClass
	"Used to mutate a PseudoContext to/from a stable Method/BlockContext.
	Notes:	Tacitly assumes that the type bits are the SAME for the source and destination!
			This method should be in ObjectMemory."

	| ccClass hdrObject ccObject |
	self inline: false.
	hdrObject _ self baseHeader: anObject.
	ccObject _ hdrObject bitAnd: 16r1F000.
	ccObject = 0 ifTrue: [
		"object has uncompact class"
		self classHeader: anObject put: aClass.
	] ifFalse: [
		"object has compact class"
		ccClass _ (self formatOfClass: aClass) bitAnd: 16rF000.
		ccClass ~= 0 ifTrue: [
			"object has compact class; class is compact"
			hdrObject _ (hdrObject bitXor: ccObject) bitOr: ccClass.
			self baseHeader: anObject put: hdrObject.
		] ifFalse: [
			"object has compact class; class is uncompact"
			self error: 'cannot mutate header from compact to uncompact'.
		]
	]