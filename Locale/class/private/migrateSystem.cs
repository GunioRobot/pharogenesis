migrateSystem
	"Locale migrateSystem"
	"Do all the necessary operations to switch to the new Locale environment."

	LocaleChangeListeners := nil.
	self
		addLocalChangedListener: HandMorph;
		addLocalChangedListener: Clipboard;
		addLocalChangedListener: Project;
		yourself