recordFieldList
	| fields |
	fields := object class fields.
	(fields first isKindOf: Array) ifFalse: [fields := Array with: fields].
	^fields collect: [ :field | field first ] thenSelect: [:name | name notNil]