removeAllButCurrent
	"Project removeAllButCurrent"

	AllProjects _ nil.
	Smalltalk garbageCollect.

	self removeAll: (Project allSubInstances copyWithout: Project current).

	AllProjects _ nil.
	Smalltalk garbageCollect.

	Smalltalk garbageCollect.
	Project rebuildAllProjects.
	^AllProjects