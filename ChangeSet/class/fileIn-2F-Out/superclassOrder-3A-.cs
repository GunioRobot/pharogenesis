superclassOrder: classes 
	"Arrange the classes in the collection, classes, in superclass order so the 
	classes can be properly filed in."

	| all list i aClass |
	list _ classes copy. 			"list is indexable"
	all _ OrderedCollection new: list size.
	[list size > 0] whileTrue: [
		i _ 0.
		[
			i _ i + 1.
			aClass _ list at: i.
			(list includesAnyOf: aClass allSuperclasses) or: [
				aClass isMeta and: [
					(list includes: aClass soleInstance) or: [
						list includesAnyOf: aClass soleInstance allSuperclasses
					] 
				].
			].
		] whileTrue.
		all addLast: aClass.
		list _ list copyWithout: aClass
	].
	^all