escapeEntities
	^ self species streamContents: [:s | self do: [:c | s nextPutAll: c escapeEntities]]
