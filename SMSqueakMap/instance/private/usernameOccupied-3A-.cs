usernameOccupied: aUsername
	"Return true if name already taken."

	^(self accountForUsername: aUsername) notNil