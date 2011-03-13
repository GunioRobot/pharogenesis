promoteToTop: aChangeSet
	"make aChangeSet the first in the list from now on"
	self gatherChangeSets.
	AllChangeSets remove: aChangeSet ifAbsent: [^ self].
	AllChangeSets add: aChangeSet.
	Smalltalk isMorphic ifTrue: [SystemWindow wakeUpTopWindowUponStartup]