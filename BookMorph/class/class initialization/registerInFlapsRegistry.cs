registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(BookMorph		nextPageButton			'NextPage'		'A button that takes you to the next page')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(BookMorph	previousPageButton 		'PreviousPage'	'A button that takes you to the previous page')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(BookMorph	authoringPrototype		'Book'			'A multi-paged structure')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(BookMorph		nextPageButton			'NextPage'		'A button that takes you to the next page')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(BookMorph	previousPageButton 		'PreviousPage'	'A button that takes you to the previous page')
						forFlapNamed: 'Supplies'.
						cl registerQuad: #(BookMorph	authoringPrototype		'Book'			'A multi-paged structure')
						forFlapNamed: 'Supplies']