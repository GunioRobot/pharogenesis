methodsWithDisabledCall
	"Answer a SortedCollection of all the methods that contain, in source  
	code, the substring indicating a disabled prim."
	"The alternative implementation  
		^ SystemNavigation new allMethodsWithSourceString: self disabledPrimStartString
									matchCase: true  
	also searches in class comments."
	| list classCount string |
	string := self disabledPrimStartString.
	list := Set new.
	'Searching all method source code...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: Smalltalk classNames size * 2 "classes with their metaclasses"
		during: [:bar |
			classCount := 0.
			SystemNavigation default
				allBehaviorsDo: [:class | 
					bar value: (classCount := classCount + 1).
					class
						selectorsDo: [:sel | 
							| src | 
							"higher priority to avoid source file accessing  
							errors"
							[src := class sourceCodeAt: sel]
								valueAt: self higherPriority.
							(src
									findString: string
									startingAt: 1
									caseSensitive: true)
									> 0
								ifTrue: [sel == #DoIt
										ifFalse: [list
												add: (MethodReference new setStandardClass: class methodSymbol: sel)]]]]].
	^ list asSortedCollection