inspectorClassOf: anObject
	"Answer the inspector class for the given object. The tool set must know which inspector type to use for which object - the object cannot possibly know what kind of inspectors the toolset provides."
	| map |
	map := Dictionary new.
	#(
		(CompiledMethod		CompiledMethodInspector)
		(CompositeEvent		OrderedCollectionInspector)
		(Dictionary			DictionaryInspector)
		(ExternalStructure	ExternalStructureInspector)
		(FloatArray			OrderedCollectionInspector)
		(OrderedCollection	OrderedCollectionInspector)
		(Set					SetInspector)
		(WeakSet			WeakSetInspector)
	) do:[:spec|
		map at: spec first put: spec last.
	].
	anObject class withAllSuperclassesDo:[:cls|
		map at: cls name ifPresent:[:inspectorName| ^Smalltalk classNamed: inspectorName].
	].
	^Inspector