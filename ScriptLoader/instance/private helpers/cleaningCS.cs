cleaningCS
	"self new cleaningCS" 
	 
	ChangeSorter removeChangeSetsNamedSuchThat: [:each | true].
	ChangeSet resetCurrentToNewUnnamedChangeSet 