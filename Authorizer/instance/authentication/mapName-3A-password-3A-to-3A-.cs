mapName: nameString password: pwdString to: aPerson
	"Insert/remove the encoding per RFC1421 of the username:password combination 
	 into/from the UserMap."

	self mapFrom: (self encode: nameString password: pwdString) to: aPerson
