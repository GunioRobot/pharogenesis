prototypicalToolWindow
	| window |
	window := PreferenceBrowserMorph withModel: self new.
	window applyModelExtent.
	^window