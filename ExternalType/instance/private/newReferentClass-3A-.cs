newReferentClass: aClass
	"The class I'm referencing has changed. Update my spec."
	referentClass _ aClass.
	self isPointerType ifTrue:[^self]. "for pointers only the referentClass changed"
	referentClass == nil ifTrue:[
		"my class has been removed - make me 'struct { void }'"
		compiledSpec _ WordArray with: (FFIFlagStructure).
	] ifFalse:[
		"my class has been changed - update my compiledSpec"
		compiledSpec _ referentClass compiledSpec.
	].