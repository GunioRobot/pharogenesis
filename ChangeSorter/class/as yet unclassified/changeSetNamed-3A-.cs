changeSetNamed: aName
	"Return the change set of the given name, or nil if none found.  1/22/96 sw"

	self gatherChangeSets.
	AllChangeSets do:
		[:aChangeSet | aChangeSet name = aName ifTrue:
			[^ aChangeSet]].
	^ nil