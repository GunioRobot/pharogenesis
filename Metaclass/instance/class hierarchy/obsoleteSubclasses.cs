obsoleteSubclasses
	"Answer the receiver's subclasses."
	thisClass == nil ifTrue:[^#()].
	^thisClass obsoleteSubclasses 
		select:[:aSubclass| aSubclass isMeta not] 
		thenCollect:[:aSubclass| aSubclass class]

	"Metaclass allInstancesDo:
		[:m | Compiler evaluate: 'subclasses_nil' for: m logged: false]"