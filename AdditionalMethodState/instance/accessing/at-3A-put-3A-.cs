at: aKey put: aValue
	"Replace the property value or pragma associated with aKey."
	
	1 to: self basicSize do:
		[:i |
		| propertyOrPragma "<Association|Pragma>" |
		(propertyOrPragma := self basicAt: i) key == aKey ifTrue:
			[propertyOrPragma isVariableBinding
				ifTrue: [propertyOrPragma value: aValue]
				ifFalse: [self basicAt: i put: aValue]]].
	^method propertyValueAt: aKey put: aValue