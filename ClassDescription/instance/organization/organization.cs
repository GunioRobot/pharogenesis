organization
	"Answer the instance of ClassOrganizer that represents the organization 
	of the messages of the receiver."

	organization==nil
		ifTrue: [organization _ 
				 ClassOrganizer defaultList: 
						methodDict keys asSortedCollection asArray].
	^organization