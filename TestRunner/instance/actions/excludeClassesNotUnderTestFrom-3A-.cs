excludeClassesNotUnderTestFrom: methods 
	| theClass |
	classesSelected do: 
		[ :class | 
		(class class selectors includes: #classNamesNotUnderTest) ifTrue: 
			[ class classNamesNotUnderTest do: 
				[ :className | 
				theClass := Smalltalk classNamed: className.
				theClass ifNotNil:[
				theClass methods do: 
					[ :each | 
					methods 
						remove: each methodReference
						ifAbsent: [  ] ].
				theClass class methods do: 
					[ :each | 
					methods 
						remove: each methodReference
						ifAbsent: [  ] ]] ] ] ]