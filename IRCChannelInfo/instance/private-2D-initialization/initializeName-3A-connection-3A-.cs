initializeName: aString  connection: aConnection
	name _ aString.
	members _ Set new.
	subscribers _ IdentitySet new.
	connection _ aConnection