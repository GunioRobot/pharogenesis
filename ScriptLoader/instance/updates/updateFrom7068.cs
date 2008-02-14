updateFrom7068
	"self new updateFrom7067"
	
	
	"SystemWindow allInstances do: [:each | each delete]."
	self script92.
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	SystemVersion newVersion: 'Squeak3.9.1'.
	self flushCaches.
	