newChanges: aChangeSet 
	"Set the system ChangeSet to be the argument, aChangeSet.  Tell the current project that aChangeSet is now its change set.  When called from Project enter:, the setChangeSet: call is redundant but harmless; when called from code that changes the current-change-set from within a project, it's vital"

	SystemChanges isolationSet: nil.
	SystemChanges _ aChangeSet.
	Smalltalk currentProjectDo:
		[:proj |
		proj setChangeSet: aChangeSet.
		aChangeSet isolationSet: proj isolationSet]