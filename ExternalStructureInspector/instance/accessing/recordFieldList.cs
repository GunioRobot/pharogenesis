recordFieldList
	| fields |
	fields _ object class fields.
	(fields first isKindOf: Array) ifFalse: [fields _ Array with: fields].
	^fields collect: [ :field | field first ] thenSelect: [:name | name notNil]