bigList
	^ Array
		with: Smalltalk classNames asOrderedCollection
		with: Smalltalk classNames reversed asOrderedCollection
		with: Smalltalk classNames asSet asArray asOrderedCollection
		with: (Smalltalk classNames
				collect: [:each | each size printString]) asOrderedCollection