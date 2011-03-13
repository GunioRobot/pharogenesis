= other
	^ other notNil 
		ifTrue:	[string = other string and: [runs = other asText runs]]
		ifFalse: [false]