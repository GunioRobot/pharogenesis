entityFor
	"return an empty entity corresponding to this tag"
	| eClass |
	eClass _ self class entityClasses at: name ifAbsent: [ ^nil ].
	^eClass forTag: self 