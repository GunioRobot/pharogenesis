arrayValueOf: oop
	self returnTypeC: 'void *'.
	self success: (self isWordsOrBytes: oop).
	^CArrayAccessor on: oop.