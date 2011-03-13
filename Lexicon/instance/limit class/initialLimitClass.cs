initialLimitClass
	"Choose a plausible initial vlaue for the limit class, and answer it"

	| oneTooFar |
	limitClass := targetClass.
	(#('ProtoObject' 'Object' 'Behavior' 'ClassDescription' 'Class' 'ProtoObject class' 'Object class') includes: targetClass name asString) ifTrue: [^ targetClass].

	oneTooFar := (targetClass isKindOf: Metaclass)
		ifTrue:
			["use the fifth back from the superclass chain for Metaclasses, which is the immediate subclass of ProtoObject class.  Print <ProtoObject class allSuperclasses> to count them yourself."
			targetClass allSuperclasses at: (targetClass allSuperclasses size - 5)]
		ifFalse:
			[targetClass allSuperclasses at: targetClass allSuperclasses size].
	[limitClass superclass ~~ oneTooFar]
		whileTrue: [limitClass := limitClass superclass].
	^ limitClass