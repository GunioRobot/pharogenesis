methodChangeTypes
	"Return an old-style dictionary of method change types."

	| dict selector record |
	dict _ IdentityDictionary new.
	methodChanges associationsDo:
		[:assn | selector _ assn key.  record _ assn value.
		dict at: selector put: record changeType].
	^ dict