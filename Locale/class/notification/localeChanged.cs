localeChanged
	#(PartsBin ParagraphEditor BitEditor FormEditor StandardSystemController ColorPickerMorph) 
		do: [ :key | Smalltalk at: key ifPresent: [ :class | class initialize ]].

	Project current localeChanged.
	self localeChangedListeners do: [:each | each localeChanged]