revoke
	"Take back all methods changed here.
	Install the original method dictionaries and organizations.
	The orignal method versions will now be the ones used."

	isolatedHead ifFalse: [^ self error: 'This isnt an isolation layer.'].
	inForce ifFalse: [^ self error: 'This layer should have been in force.'].
	changeSet revoke.	
	inForce := false.
