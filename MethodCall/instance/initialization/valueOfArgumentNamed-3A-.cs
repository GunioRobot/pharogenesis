valueOfArgumentNamed: aName
	"Answer the value of the given arguement variable"

	| anIndex |
	anIndex := self methodInterface argumentVariables findFirst:
		[:aVariable | aVariable variableName = aName].
	^ anIndex > 0
		ifTrue:
			[arguments at: anIndex]
		ifFalse:
			[self error: 'variable not found']