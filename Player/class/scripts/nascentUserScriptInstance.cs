nascentUserScriptInstance
	"Answer a new script object of the appropriate class"

	| classToUse |
	classToUse _ Preferences universalTiles
		ifTrue:	[MethodWithInterface]
		ifFalse:	[UniclassScript].
	^ classToUse new