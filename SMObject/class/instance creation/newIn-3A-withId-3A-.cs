newIn: aMap withId: anUUIDString
	"Create a new object in a given SMSqueakMap with a given UUID as a String.
	This method is used when we create instances from a logfile etc."

	^(self new) map: aMap id: (UUID fromString: anUUIDString)