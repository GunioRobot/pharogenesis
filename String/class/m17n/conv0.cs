conv0

	ArrayedCollection subclass: #AbstractString
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Multilingual-BaseClasses'.

	ClassBuilder new
		name: #String
		inEnvironment: String environment
		subclassOf: (Smalltalk at: #AbstractString)
		type: String typeOfClass
		instanceVariableNames: String instanceVariablesString
		classVariableNames: String classVariablesString
		poolDictionaries: String sharedPoolsString
		category: (SystemOrganization categoryOfElement: #String) asString
		unsafe: true.

	String organization categories do: [:cat |
		(Smalltalk at: #AbstractString) organization addCategory: cat
	].
