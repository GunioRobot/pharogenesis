update: aSelector
	aSelector = #filter ifFalse: [^ self].
	(model wantsButton)
			ifTrue: [self addButton: model filter buttonMorph]
			ifFalse: [self removeButton]