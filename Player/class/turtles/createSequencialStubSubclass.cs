createSequencialStubSubclass

	| instVarString classInstVarString aName aClass |
	instVarString _ KedamaSequenceExecutionStub instVarNames.
	classInstVarString _ ''.
	aName _ self chooseUniqueTurtleClassName.
	aClass _ self subclass: aName instanceVariableNames: instVarString 
		classVariableNames: '' poolDictionaries: '' category: self categoryForUniclasses.
	classInstVarString size > 0 ifTrue:
		[aClass class instanceVariableNames: classInstVarString].
	aClass copyAllCategoriesUnobtrusivelyFrom: KedamaSequenceExecutionStub.
	^ aClass
