actionMap
	"Answer an action map"

	| actionMap |
	actionMap := self valueOfProperty: #actionMap.
	actionMap ifNil:
		[actionMap _ self createActionMap].
	^ actionMap