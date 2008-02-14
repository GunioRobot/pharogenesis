updateFrom7070
	"self new updateFrom7070"

	self script93.
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	self flushCaches.
	Preferences enable: #serverMode.
	
	