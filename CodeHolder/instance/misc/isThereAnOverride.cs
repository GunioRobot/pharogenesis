isThereAnOverride
	"Answer whether any subclass of my selected class implements my selected selector"

	| aName aList aClass |
	(aName _ self selectedMessageName) ifNil: [^ false].

	aList _ Smalltalk allImplementorsOf: aName.
	aClass _ self selectedClassOrMetaClass.
	aList do:
		[:element | MessageSet parse: element toClassAndSelector:
			[:cl :sel | (cl inheritsFrom: aClass) ifTrue: [^ true]]].
	^ false