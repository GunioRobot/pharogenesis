isThisAnOverride
	"Answer whether any superclass of my selected class implements my selected selector"
	| aName aClass |
	aName _ self selectedMessageName
				ifNil: [^ false].
	aClass _ self selectedClassOrMetaClass.
	aClass allSuperclassesDo: [ :cls | (cls includesSelector: aName) ifTrue: [ ^true ]].
	^ false