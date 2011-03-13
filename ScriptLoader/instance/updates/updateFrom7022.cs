updateFrom7022

	"self new updateFrom7022"
	""
	
	self script58.
	self flushCaches.
	MCDefinition clearInstances.

	MenuIcons initializeIcons.

	"Postscript from Changeset:  1044-TrashCanMorphCleanUp-dgd"
	World submorphs
		select: [:each | each isKindOf: TrashCanMorph]
		thenDo: [:each | each delete].

	World restoreFlapsDisplay.

	Preferences setNotificationParametersForStandardPreferences.
	World roundUpStrays.
	ParagraphEditor initialize.
	SystemProgressMorph reset.
	MenuIcons initializeIcons.