templateForSubclassOf: priorClassName category: systemCategoryName 
	"Answer an expression that can be edited and evaluated in order to define a new class, given that the class previously looked at was as given"

	Preferences printAlternateSyntax 
		ifTrue: [^ priorClassName asString, ' subclass (#NameOfSubclass)
	instanceVariableNames ('''')
	classVariableNames ('''')
	poolDictionaries ('''')
	category (''' , systemCategoryName asString , ''')']
		ifFalse: [^ priorClassName asString, ' subclass: #NameOfSubclass
	instanceVariableNames: ''''
	classVariableNames: ''''
	poolDictionaries: ''''
	category: ''' , systemCategoryName asString , '''']