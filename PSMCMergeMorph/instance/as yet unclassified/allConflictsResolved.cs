allConflictsResolved
	"Answer whether all conflicts were resolved."
	
	^(self model ifNil: [^false]) isMerged