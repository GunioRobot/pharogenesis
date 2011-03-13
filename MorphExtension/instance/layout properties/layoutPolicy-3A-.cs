layoutPolicy: aLayoutPolicy
	aLayoutPolicy == nil
		ifTrue:[self removeProperty: #layoutPolicy]
		ifFalse:[self setProperty: #layoutPolicy toValue: aLayoutPolicy].
