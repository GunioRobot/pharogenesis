sharedFieldsWithBaseDo: fieldsAndBaseBlock

	| fields base |
	fields _ self class allInstVarNames allButFirst: (base _ PDARecord superclass instSize).
	fieldsAndBaseBlock value: fields value: base