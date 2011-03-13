superclassOrder: classes 
	"Arrange the classes in the collection, classes, in superclass order so the 
	classes can be properly filed in."

	| all list i aClass superClass |
	list _ classes copy. 			"list is indexable"
	all _ OrderedCollection new: list size.
	[list size > 0]
		whileTrue: 
			[aClass _ list first.
			superClass _ aClass superclass.
			"Make sure it doesn't have an as yet uncollected superclass"
			[superClass == nil or: [list includes: superClass]]
				whileFalse: [superClass _ superClass superclass].
			i _ 1.
			[superClass == nil]
				whileFalse: 
					[i _ i + 1.
					aClass _ list at: i.
					superClass _ aClass superclass.
					"check as yet uncollected superclass"
					[superClass == nil or: [list includes: superClass]]
						whileFalse: [superClass _ superClass superclass]].
			all addLast: aClass.
			list _ list copyWithout: aClass].
	^all