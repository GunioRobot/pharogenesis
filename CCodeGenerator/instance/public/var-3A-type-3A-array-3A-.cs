var: varName type: type array: array
	self
		var: varName
		declareC: (String streamContents: [:s |
			s nextPutAll: type.
			s space.
			s nextPutAll: varName.
			s nextPutAll: '[] = {'.
			self printArray: array on: s.
			s nextPut: $}])