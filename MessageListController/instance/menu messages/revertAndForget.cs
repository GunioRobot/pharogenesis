revertAndForget
	"Revert to the previous version of the current method, and tell the changes mgr to forget that it was ever changed.  Danger!  Use only if you really know what you're doing!"

	self controlTerminate.
	self revertToPreviousVersion.
	Smalltalk changes removeSelectorChanges: model selectedMessageName class: model selectedClassOrMetaClass.
	Transcript cr; show: 'Method ', model selectedClass name, '.', model selectedMessage name, ' reverted to previous version and removed from current Change Set, at ', Time dateAndTimeNow printString.
	self controlInitialize