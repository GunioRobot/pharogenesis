testResumablePass

	| result |
	result _ [Notification signal. 4] 
		on: Notification 
		do: [:ex | ex pass. ex return: 5].
	self assert: result == 4
