changedClasses
	"Answer a OrderedCollection of changed or edited classes.  Not including removed classes.  Sort alphabetically by name."

	"Much faster to sort names first, then convert back to classes.  Because metaclasses reconstruct their name at every comparison in the sorted collection.
	8/91 sw chgd to filter out non-existent classes (triggered by problems with class-renames"
	classChanges == nil ifTrue: [^ OrderedCollection new].
	^ self changedClassNames collect: 
		[:className | Smalltalk classNamed: className]
			thenSelect:
				[:aClass | aClass notNil]