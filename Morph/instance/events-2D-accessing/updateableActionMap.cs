updateableActionMap
	"Answer an updateable action map, saving it in my #actionMap property"
	
	| actionMap |
	actionMap := self valueOfProperty: #actionMap.
	actionMap ifNil:
		[actionMap _ self createActionMap.
		self setProperty: #actionMap toValue: actionMap].
	^ actionMap