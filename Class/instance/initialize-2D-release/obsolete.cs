obsolete
	"Change the receiver and all of its subclasses to an obsolete class."
	self == Object 
		ifTrue:[^self error:'Object is NOT obsolete'].
	name _ 'AnObsolete' , name.
	Object class instSize + 1 to: self class instSize do:
		[:i | self instVarAt: i put: nil]. "Store nil over class instVars."
	classPool _ nil.
	sharedPools _ nil.
	self class obsolete.
	super obsolete.
