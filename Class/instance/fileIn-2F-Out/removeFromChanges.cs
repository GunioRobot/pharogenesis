removeFromChanges
	"References to the receiver, a class, and its metaclass should no longer be included in the system ChangeSet.
	7/18/96 sw: call removeClassAndMetaClassChanges:"

	Smalltalk changes removeClassAndMetaClassChanges: self