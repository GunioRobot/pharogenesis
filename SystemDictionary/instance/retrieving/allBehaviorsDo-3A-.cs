allBehaviorsDo: aBlock 
	"Evaluate the argument, aBlock, for each kind of Behavior in the system 
	(that is, Object and its subclasses).
	ar 7/15/1999: The code below will not enumerate any obsolete or anonymous
	behaviors for which the following should be executed:

		Smalltalk allObjectsDo:[:obj| obj isBehavior ifTrue:[aBlock value: obj]].

	but what follows is way faster than enumerating all objects."

	aBlock value: ProtoObject.
	ProtoObject allSubclassesDoGently: aBlock.		"don't bring in ImageSegments"

	"Classes outside the ProtoObject hierarchy"
	Class subclassesDo: [:aClass |
		(aClass == ProtoObject class
			or: [aClass isInMemory not
			or: [aClass isMeta not]]) ifFalse:
			["Enumerate the non-meta class and its subclasses"
			aBlock value: aClass soleInstance.
			aClass soleInstance allSubclassesDoGently: aBlock]].