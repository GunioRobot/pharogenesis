addClass: aClass 
	"Add the variables and methods of the given class to the code base."
	| source |
	self checkClassForNameConflicts: aClass.
	self addClassVarsFor: aClass.
	"ikp..."
	self addPoolVarsFor: aClass.
	variables addAll: aClass instVarNames.
	self retainMethods: aClass requiredMethodNames.
	
	'Adding Class ' , aClass name , '...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: aClass selectors size
		during: [:bar | aClass selectors
				doWithIndex: 
					[:sel :i | 
					bar value: i.
					source _ aClass sourceCodeAt: sel.
					self addMethod: ((Compiler new
							parse: source
							in: aClass
							notifying: nil)
							asTranslationMethodOfClass: self translationMethodClass)]].
	aClass declareCVarsIn: self