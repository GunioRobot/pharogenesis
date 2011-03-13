keystroke: aChar from: aMorph
	self isEmpty ifTrue: [^ self].
	(self actionsForKeystroke: aChar)
		do: [:action | 
			action announcer: self announcer.
			action trigger].
	(self servicesForKeystroke: aChar)
		do: [:service | service condExecuteFor: self requestor]