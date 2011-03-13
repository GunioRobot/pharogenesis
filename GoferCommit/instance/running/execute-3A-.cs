execute: aWorkingCopy
	| targets version |
	targets := repositories at: aWorkingCopy.
	targets isEmpty
		ifTrue: [ self error: 'No repository found for ' , aWorkingCopy packageName printString ]. 
	version := [ aWorkingCopy newVersion ]
		on: MCVersionNameAndMessageRequest
		do: [ :notifcation |
			self message isNil
				ifTrue: [ message := notifcation outer last ].
			notifcation resume: (Array with: notifcation suggestedName with: self message) ].
	targets first
		storeVersion: version