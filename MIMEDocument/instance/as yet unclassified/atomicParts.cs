atomicParts
	self isMultipart ifFalse: [^ OrderedCollection with: self].
	^ self parts inject: OrderedCollection new into: [:col :part | col , part atomicParts]