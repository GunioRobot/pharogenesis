recoverFromMDFault
	(organization isMemberOf: Array) ifFalse: [^ self error: 'oops'].
	methodDict _ organization first.
	organization _ organization second.