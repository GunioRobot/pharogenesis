deferred: aBoolean
	aBoolean 
		ifTrue:[self setProperty: #deferred toValue: true]
		ifFalse:[self removeProperty: #deferred]