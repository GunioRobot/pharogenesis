askForDefault
	"Ask for the default implementor"
	self registeredClasses isEmpty 
		ifTrue:[^ default _ nil].
	self registeredClasses size = 1 
		ifTrue:[^ default _ self registeredClasses anyOne].
	default := UIManager default 
		chooseFrom: (self registeredClasses collect:[:each| each name printString])
		values: self registeredClasses
		title: 'Which ', self appName, ' would you prefer?'.
	^default.