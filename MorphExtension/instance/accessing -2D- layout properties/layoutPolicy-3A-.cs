layoutPolicy: aLayoutPolicy 
	aLayoutPolicy
		ifNil: [self removeProperty: #layoutPolicy]
		ifNotNil: [self setProperty: #layoutPolicy toValue: aLayoutPolicy]