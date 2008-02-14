updateFrom7072
	"self new updateFrom7072"

	self script95.
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	self flushCaches.
	
	
	