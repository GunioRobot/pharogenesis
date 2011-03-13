matchingClassesForPattern: aString

	^TestCase allSubclasses select: [:class |
		aString match: class name]