superclassOrder: classes
	"Arrange the classes in the collection, classes, in superclass order so the 
	classes can be properly filed in. Do it in sets instead of ordered collections.
	SqR 4/12/2000 22:04"

	| all list aClass inclusionSet aClassIndex cache |

	list _ classes copy. "list is indexable"
	inclusionSet _ list asSet. cache _ Dictionary new.
	all _ OrderedCollection new: list size.
	list size timesRepeat:
		[
			aClassIndex _ list findFirst: [:one | one isNil not and: 
				[self doWeFileOut: one given: inclusionSet cache: cache]].
			aClass _ list at: aClassIndex.
			all addLast: aClass.
			inclusionSet remove: aClass.
			list at: aClassIndex put: nil
		].
	^all