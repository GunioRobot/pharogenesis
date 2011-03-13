servers
	"Return all registered servers.  Each is an association (name -> server)"

	| all |
	all _ OrderedCollection new.
	Smalltalk associationsDo: [:assoc |
		(assoc value isKindOf: self) ifTrue: [all add: assoc copy]].
	^ all