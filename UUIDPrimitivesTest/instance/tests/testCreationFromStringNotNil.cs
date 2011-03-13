testCreationFromStringNotNil
	| uuid string |
	string _ UUID new asString.
	uuid _ UUID fromString: string.
	self should: [uuid size = 16].
	self should: [uuid asString size = 36].

