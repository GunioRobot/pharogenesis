= method
	"Answer whether the receiver implements the same code as the 
	argument, method."
	(method isKindOf: CompiledMethod) ifFalse: [^false].
	self size = method size ifFalse: [^false].
	self header = method header ifFalse: [^false].
	self literals = method literals ifFalse: [^false].
	self initialPC to: self endPC do:
		[:i | (self at: i) = (method at: i) ifFalse: [^false]].
	^true