= other
	^ other isText
		ifTrue:	[string = other string and: [runs = other asText runs]]
		ifFalse: [false]