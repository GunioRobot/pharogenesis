mutate: oldClass to: newClass
	"Mutate oldClass to newClass.
	Convert all instances of oldClass and recursively update
	the subclasses."
	| subs newSubclass oldSubclass |
	subs _ oldClass subclasses asArray.

	"Walk down"
	1 to: subs size do:[:i|
		oldSubclass _ subs at: i.
		self showProgressFor: oldSubclass.
		"Create the new class"
		newSubclass _ self reshapeClass: oldSubclass to: nil super: newClass.
		self mutate: oldSubclass to: newSubclass.
	].
	oldClass obsolete.
	newClass isObsolete ifTrue:[newClass obsolete].
	^newClass