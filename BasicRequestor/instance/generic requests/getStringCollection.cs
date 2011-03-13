getStringCollection
	caption := caption, Character cr asString, 'Separate items with space'.
	^ (self getString findTokens: ' ') collect: [:each | each copyWithoutAll: ' ' ]