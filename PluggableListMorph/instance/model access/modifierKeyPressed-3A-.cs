modifierKeyPressed: aChar 
	| args |
	keystrokeActionSelector == nil ifTrue: [^ nil].
	args _ keystrokeActionSelector numArgs.
	args = 1 ifTrue: [^ model perform: keystrokeActionSelector with: aChar].
	args = 2 ifTrue: [^ model
			perform: keystrokeActionSelector
			with: aChar
			with: self].
	^ self error: 'keystrokeActionSelector must be a 1- or 2-keyword symbol'