destroyFlap
	| reply request |
	request _ self isGlobal
		ifTrue:
			['Caution -- this would permanently
remove this flap, so it would no longer be
available in this or any other project.
Do you really want to this? ']
		ifFalse:
			['Caution -- this is permanent!  Do
you really want to do this? '].
	reply _ self confirm: request orCancel: [^ self].
	reply ifTrue:
		[self isGlobal
			ifTrue:
				[Utilities removeFlapTab: self keepInList: false]
			ifFalse:
				[referent isInWorld ifTrue: [referent delete].
				self delete]]