globalFlapWithIDEnabledString: aFlapID
	"Answer the string to be shown in a menu to represent the status of the givne flap regarding whether it it should be shown in this project."

	| aFlapTab wording |
	aFlapTab _ self globalFlapTabWithID: aFlapID.
	wording _ aFlapTab ifNotNil: [aFlapTab wording] ifNil: ['(',  aFlapID, ')'].
	^ (Project current isFlapIDEnabled: aFlapID)
		ifTrue:
			['<on>', wording]
		ifFalse:
			['<off>', wording]