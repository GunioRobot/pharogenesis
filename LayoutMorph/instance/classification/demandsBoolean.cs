demandsBoolean
	self flag: #deferred.
	"Answer whether the receiver insists on a boolean-valued droppee"
	(submorphs size < 2 or: [(submorphs second isKindOf: StringMorph) not]) ifTrue:
		[^ false].
	^ submorphs second contents = 'Test'