emptyTrash
	userStuffPalette pages do: [:pp | 
		(pp hasProperty: #trash) ifTrue: [
			userStuffPalette goToPageMorph: pp.
			userStuffPalette deletePage]].
