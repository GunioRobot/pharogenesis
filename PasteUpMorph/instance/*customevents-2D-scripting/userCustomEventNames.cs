userCustomEventNames
	| reg |
	reg _ self valueOfProperty: #userCustomEventsRegistry ifAbsent: [ ^#() ].
	^reg keys asArray sort