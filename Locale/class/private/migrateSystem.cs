migrateSystem
	"Locale migrateSystem"
	"Do all the necessary operations to switch to the new Locale environment."

	LocaleChangeListeners _ nil.
	self
		addLocalChangedListener: HandMorph;
		addLocalChangedListener: Clipboard;
		addLocalChangedListener: Vocabulary;
		addLocalChangedListener: PartsBin;
		addLocalChangedListener: Project;
		addLocalChangedListener: PaintBoxMorph;
		yourself