userCustomEventsRegistry
	^self valueOfProperty: #userCustomEventsRegistry ifAbsentPut: [ IdentityDictionary new ].