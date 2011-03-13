obsoleteMethodReferences
	"SystemNavigation default obsoleteMethodReferences"

	"Open a browser on all referenced behaviors that are obsolete"

	| obsClasses obsRefs references |
	references := Array new writeStream.
	obsClasses := self obsoleteBehaviors.
	'Scanning for methods referencing obsolete classes' 
		displayProgressAt: Sensor cursorPoint
		from: 1
		to: obsClasses size
		during: 
			[:bar | 
			obsClasses keysAndValuesDo: 
					[:index :each | 
					bar value: index.
					obsRefs := PointerFinder pointersTo: each except: obsClasses.
					obsRefs do: 
							[:ref | 
							"Figure out if it may be a global"

							(ref isVariableBinding and: [ref key isString	"or Symbol"]) 
								ifTrue: 
									[(Utilities pointersTo: ref) do: 
											[:meth | 
											(meth isKindOf: CompiledMethod) 
												ifTrue: [meth methodReference ifNotNil: [:mref | references nextPut: mref]]]]]]].
	^references contents