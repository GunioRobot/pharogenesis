askForDefault
	| menu |
	self registeredClasses isEmpty ifTrue:
		[self inform: 'There are no ', self appName, ' applications registered.'.
		^ default _ nil].
	self registeredClasses size = 1 ifTrue:
		[^ default _ self registeredClasses anyOne].
	
	menu _ CustomMenu new.
	self registeredClasses do: [:c | menu add: c name printString action: c].
	default _  menu startUpWithCaption: 'Which ', self appName, ' would you prefer?'.
	default ifNil: [default := self registeredClasses first].
	^default.