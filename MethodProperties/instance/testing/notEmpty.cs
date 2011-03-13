notEmpty
	^(properties notNil and: [properties notEmpty])
	   or: [pragmas notNil and: [pragmas notEmpty]]