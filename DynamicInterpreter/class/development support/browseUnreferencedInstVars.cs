browseUnreferencedInstVars
	"DynamicInterpreter browseUnreferencedInstVars"

	| instList unrefed classList |
	classList _ DynamicInterpreterSimulator withAllSuperclasses remove: Object; yourself.
	unrefed _ DynamicInterpreterSimulator allInstVarNames asSet.
	classList do: [:thisClass |
		instList _ unrefed asArray.
		('Checking' , thisClass name , '...')
			displayProgressAt: Sensor cursorPoint
			from: 1 to: instList size
			during: [:bar |
				instList doWithIndex: [:instVar :index |
					bar value: index.
					(thisClass whichSelectorsAccess: instVar) isEmpty
						ifFalse: [unrefed remove: instVar]]]].
	unrefed isEmpty
		ifTrue: [PopUpMenu notify: 'no unreferenced inst vars']
		ifFalse: [unrefed inspect]