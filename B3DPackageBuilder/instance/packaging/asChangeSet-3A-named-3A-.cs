asChangeSet: pi named: csName
	"Create a change set from all the stuff that's in this PI"
	| cs |
	cs := ChangeSorter changeSetNamed: csName.
	cs ifNotNil:[ChangeSorter removeChangeSet: cs].
	cs := ChangeSorter basicNewChangeSet: csName.
	Cursor wait showWhile:[
		pi classesAndMetaClasses do:[:each|
			cs addClass: each.
			cs reorganizeClass: each.
			each isMeta ifFalse:[
				each organization commentRemoteStr ifNotNil:[cs commentClass: each].
			].
			each selectorsAndMethodsDo:[:sel :meth|
				cs noteNewMethod: meth forClass: each selector: sel priorMethod: nil.
			].
		].
		pi extensionMethods do:[:mref|
			cs noteNewMethod: (mref actualClass compiledMethodAt: mref methodSymbol)
				forClass: mref actualClass
				selector: mref methodSymbol
				priorMethod: nil.
		].
	].
	^cs