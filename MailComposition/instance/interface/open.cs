open
	"open an interface"
	Smalltalk isMorphic
		ifTrue: [ self openInMorphic ]
		ifFalse: [ self openInMVC ]