needsConversion
	"Answer whether conversion is required for the receiver's object class."

	^(self objectClass includesBehavior: String) not