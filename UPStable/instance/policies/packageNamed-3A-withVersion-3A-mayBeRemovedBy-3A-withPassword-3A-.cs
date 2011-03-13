packageNamed: packageName  withVersion: version  mayBeRemovedBy: user  withPassword: password
	(user = masterUser and: [ password = masterPassword ])
		ifTrue: [ ^UPolicyResponse allowed ]
		ifFalse: [ ^UPolicyResponse denied ]