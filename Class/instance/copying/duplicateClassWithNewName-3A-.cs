duplicateClassWithNewName: aSymbol

	| copysName class newDefinition |
	
	copysName := aSymbol asSymbol.
	copysName = self name ifTrue: [^ self].
	(Smalltalk includesKey: copysName) ifTrue: [^ self error: copysName , ' already exists'].
		
	newDefinition := self definition copyReplaceAll: '#' , self name asString with: '#' , copysName asString.
	class := Compiler evaluate: newDefinition logged: true.
	class class instanceVariableNames: self class instanceVariablesString.
	class copyAllCategoriesFrom: self.
	class class copyAllCategoriesFrom: self class.
	^class