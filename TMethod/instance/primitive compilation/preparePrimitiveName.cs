preparePrimitiveName
	"Prepare the selector for this method in translation"
	| aClass |
	aClass _ definingClass.
	primitive = 117 
		ifTrue:[selector _ ((aClass includesSelector: selector)
					ifTrue: [aClass compiledMethodAt: selector]
					ifFalse: [aClass class compiledMethodAt: selector]) literals first at: 2.
				export _ true]
		ifFalse:[selector _ 'prim', aClass name, selector].

