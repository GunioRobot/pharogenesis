updateFrom7066
	"self new updateFrom7066"
	
	self script91.
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	SystemVersion newVersion: 'Squeak3.9'.
	self flushCaches.
	