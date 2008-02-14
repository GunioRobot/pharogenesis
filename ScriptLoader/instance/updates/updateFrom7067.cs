updateFrom7067
	"self new updateFrom7067"
	
	self script92. "loading multilingual is sync"
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	self flushCaches.
	