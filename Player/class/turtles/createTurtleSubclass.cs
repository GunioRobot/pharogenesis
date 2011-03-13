createTurtleSubclass

	| instVarString classInstVarString aName aClass |
	instVarString _ KedamaTurtleVectorPlayer instVarNames.
	classInstVarString _ ''.
	aName _ self chooseUniqueTurtleClassName.
	aClass _ self subclass: aName instanceVariableNames: instVarString 
		classVariableNames: '' poolDictionaries: '' category: self categoryForUniclasses.
	classInstVarString size > 0 ifTrue:
		[aClass class instanceVariableNames: classInstVarString].
	aClass copyAllCategoriesUnobtrusivelyFrom: KedamaTurtleVectorPlayer.
	^ aClass
