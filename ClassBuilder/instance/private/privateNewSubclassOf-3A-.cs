privateNewSubclassOf: newSuper
	"Create a new meta and non-meta subclass of newSuper"
	"WARNING: This method does not preserve the superclass/subclass invariant!"
	| newSuperMeta newMeta |
	newSuperMeta _ newSuper ifNil:[Class] ifNotNil:[newSuper class].
	newMeta _ Metaclass new.
	newMeta 
		superclass: newSuperMeta 
		methodDictionary: MethodDictionary new 
		format: newSuperMeta format.
	^newMeta new
