organization
	"Answer the instance of ClassOrganizer that represents the organization 
	of the messages of the receiver."

	organization ifNil:
		[organization _ ClassOrganizer defaultList: 
						self methodDict keys asSortedCollection asArray].
	(organization isMemberOf: Array) ifTrue:
		[self recoverFromMDFault].
	^ organization