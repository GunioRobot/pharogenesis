cleaningCS
	"self new cleaningCS" 
	 
	ChangesOrganizer removeChangeSetsNamedSuchThat: [:each | true].
	ChangeSet resetCurrentToNewUnnamedChangeSet 