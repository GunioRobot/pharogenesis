testResumableOuter

	| result |
	result _ [Notification signal. 4] 
		on: Notification 
		do: [:ex | ex outer. ex return: 5].
	self assert: result == 5
