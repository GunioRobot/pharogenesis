fixObsoleteMethodsFrom: oldClasses map: obsoleteClasses
	"Fix the methods of the obsolete classes"
	| nLits tempMethod |
	oldClasses do:[:class|
		obsoleteClasses at: class ifPresent:[:tempClass|
			class selectorsAndMethodsDo:[:sel :meth|
				"Create a clean copy for the temps"
				tempMethod _ meth copy.
				"Fix the super sends"
				tempMethod sendsToSuper ifTrue:[
					nLits _ tempMethod numLiterals.
					"Hack the method class in the temp class"
					tempMethod literalAt: nLits put: 
						(Association new value: 
							(obsoleteClasses at: class ifAbsent:[class])).
				].
				"Install in tempClass"
				tempClass addSelector: sel withMethod: tempMethod.
			].
		].
	].