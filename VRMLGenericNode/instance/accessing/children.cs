children
	| attr |
	attr := self nodeSpec getFieldNamed: 'children'.
	^attr ifNotNil:[self getAttributeValue: attr].