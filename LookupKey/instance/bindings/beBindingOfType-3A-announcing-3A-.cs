beBindingOfType: aClass announcing: aBool
	"Make the receiver a global binding of the given type"
	| old new |
	(Smalltalk associationAt: self key) == self
		ifFalse:[^self error:'Not a global variable binding'].
	self class == aClass ifTrue:[^self].
	old _ self.
	new _ aClass key: self key value: self value.
	old become: new.
	"NOTE: Now self == read-only (e.g., the new binding)"
	^self recompileBindingsAnnouncing: aBool