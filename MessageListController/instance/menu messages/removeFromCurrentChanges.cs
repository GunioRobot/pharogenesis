removeFromCurrentChanges
	"Tell the changes mgr to forget that the current msg was changed."

	self controlTerminate.
	Smalltalk changes removeSelectorChanges: model selectedMessageName class: model selectedClassOrMetaClass.
	Transcript cr; show: 'Method ', model selectedClass name, '.', model selectedMessage name, ' removed from current Change Set, at ', Time dateAndTimeNow printString.
	self controlInitialize