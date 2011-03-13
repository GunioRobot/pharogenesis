package: package mayBeAddedBy: user withPassword: password
	^(user = masterUser and: [ password = masterPassword ])
		ifTrue: [ UPolicyResponse allowed ]
		ifFalse: [ UPolicyResponse denied ]