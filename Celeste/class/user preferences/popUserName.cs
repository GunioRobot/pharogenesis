popUserName
	"Answer the user's username on the POP server"

	(PopUserName isNil or: [PopUserName isEmpty])
		ifTrue: [self setPopUserName].

	PopUserName isEmpty ifTrue: [ 
		self error: 'no POP user name specified' ].

	^PopUserName