accountForUsername: username
	"Find account given username. The username used
	is the developer initials of the account."

	^self users at: username ifAbsent: [nil]