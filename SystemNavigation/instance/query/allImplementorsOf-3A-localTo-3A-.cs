allImplementorsOf: aSelector  localTo: aClass
	"Answer a SortedCollection of all the methods that implement the message 
	aSelector in, above, or below the given class."

	| aSet cls |
	aSet _ Set new.
	cls _ aClass theNonMetaClass.
	Cursor wait showWhile: [
		cls withAllSuperAndSubclassesDoGently:
			[:class |
			(class includesSelector: aSelector)
				ifTrue: [aSet add: class name, ' ', aSelector]].
		cls class withAllSuperAndSubclassesDoGently:
			[:class |
			(class includesSelector: aSelector)
				ifTrue: [aSet add: class name, ' ', aSelector]]
	].
	^aSet asSortedCollection