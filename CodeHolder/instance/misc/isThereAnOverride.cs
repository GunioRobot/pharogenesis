isThereAnOverride
	"Answer whether any subclass of my selected class implements my 
	selected selector"
	| aName aClass |
	aName _ self selectedMessageName
				ifNil: [^ false].
	aClass _ self selectedClassOrMetaClass.
	aClass allSubclassesDo: [ :cls | (cls includesSelector: aName) ifTrue: [ ^true ]].
	^ false