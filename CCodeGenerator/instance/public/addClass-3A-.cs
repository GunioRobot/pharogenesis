addClass: aClass
	"Add the variables and methods of the given class to the code base."
	| source |
	self checkClassForNameConflicts: aClass.
	aClass classPool associationsDo: [ :assoc |
		constants at: assoc key put: (TConstantNode new setValue: assoc value).
	].
	"ikp..."
	aClass sharedPools do: [:pool |
		pool associationsDo: [ :assoc |
			constants at: assoc key put: (TConstantNode new setValue: assoc value).
		].
	].
	variables addAll: aClass instVarNames.
'Adding Class ' , aClass name , '...'
displayProgressAt: Sensor cursorPoint
from: 0 to: aClass selectors size
during: [:bar |
	aClass selectors doWithIndex: [ :sel :i | bar value: i.
		source _ aClass sourceCodeAt: sel.
		self addMethod: ((Compiler new parse: source in: aClass notifying: nil) asTMethodFromClass: aClass).
	]].