deleteCustomEvent
	| userEvents eventName |
	userEvents :=  ScriptingSystem userCustomEventNames.
	eventName := (SelectionMenu selections: userEvents) startUpWithCaption: 'Remove which event?' at: ActiveHand position allowKeyboard: true.
	eventName ifNotNil: [ ScriptingSystem removeUserCustomEventNamed: eventName ].
	self class allSubInstancesDo: [ :ea | ea status = eventName ifTrue: [ ea status: #normal ]]