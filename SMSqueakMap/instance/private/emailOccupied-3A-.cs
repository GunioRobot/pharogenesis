emailOccupied: aUsername
	"Return true if email already taken."

	^(self accountForEmail: aUsername) notNil