addAllMethodsToCurrentChangeSet
	"Add all the methods in the selected class or metaclass to the current change set.  You ought to know what you're doing before you invoke this!"

	| aClass |
	(aClass _ self selectedClassOrMetaClass) ifNotNil:
		[aClass selectors do:
			[:sel |
				ChangeSet current adoptSelector: sel forClass: aClass].
		self changed: #annotation]