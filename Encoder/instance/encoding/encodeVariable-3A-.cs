encodeVariable: name
	^ self encodeVariable: name ifUnknown: [ self undeclared: name ]