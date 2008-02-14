updateFrom7071
	"self new updateFrom7071"

	self script94.
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	self flushCaches.
	Preferences enable: #serverMode.
	
	