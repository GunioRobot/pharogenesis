testErrorClassCreation
	| tmpCategory trait cls2 |
	tmpCategory := 'TemporaryGeneratedClasses'.
	
	Smalltalk at: #AClass ifPresent: [:v | v removeFromSystem].
	Smalltalk at: #AClass2 ifPresent: [:v | v removeFromSystem].
	Smalltalk at: #TMyTrait ifPresent: [:v | v removeFromSystem].
	
	trait := Trait named: #TMyTrait uses: {} category: tmpCategory.
	
	"----------------"
"	Object subclass: #AClass
			instanceVariableNames: '' classVariableNames: '' poolDictionaries: '' category: tmpCategory.
"
	"----------------"
	 nil subclass: #AClass
				instanceVariableNames: ''
				classVariableNames: '' poolDictionaries: '' category: tmpCategory.

	"----------------"
	cls2 := (Smalltalk at: #AClass) subclass: #AClass2
				uses: trait
				instanceVariableNames: ''
				classVariableNames: '' poolDictionaries: '' category: tmpCategory.
	"----------------"
	
	Object subclass: #AClass
			instanceVariableNames: '' classVariableNames: '' poolDictionaries: '' category: tmpCategory.


	self assert: (trait users asArray = {cls2}).
	self assert: (cls2 traits asArray = {trait}).

	"----------------"
	
	Smalltalk at: #AClass ifPresent: [:v | v removeFromSystem].
	Smalltalk at: #AClass2 ifPresent: [:v | v removeFromSystem].
	Smalltalk at: #TMyTrait ifPresent: [:v | v removeFromSystem].
