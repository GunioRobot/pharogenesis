changeSetCategory
	"Answer the current changeSetCategory object that governs which change sets are shown in this ChangeSorter"

	^ changeSetCategory ifNil:
		[self setDefaultChangeSetCategory]