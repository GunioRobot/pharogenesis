obsoleteMethodReferences
	"Smalltalk obsoleteMethodReferences"
	"Smalltalk browseObsoleteMethodReferences"
	"Open a browser on all referenced behaviors that are obsolete"
	| obsClasses obsRefs references |
	self deprecated: 'Use SystemNavigation default obsoleteMethodReferences'.
	references _ WriteStream on: Array new.
	obsClasses _ self obsoleteBehaviors.
	'Scanning for methods referencing obsolete classes' displayProgressAt: Sensor cursorPoint
		from: 1 to: obsClasses size during:[:bar|
	obsClasses keysAndValuesDo:[:index :each|
		bar value: index.
		obsRefs _ self pointersTo: each except: obsClasses.
		obsRefs do:[:ref|
			"Figure out if it may be a global"
			((ref isVariableBinding) and:[ref key isString "or Symbol"]) ifTrue:[
				(self pointersTo: ref) do:[:meth|
					(meth isKindOf: CompiledMethod) ifTrue:[
						meth methodReference ifNotNilDo:[:mref|
							references nextPut: mref]]]]]].
	].
	^references contents