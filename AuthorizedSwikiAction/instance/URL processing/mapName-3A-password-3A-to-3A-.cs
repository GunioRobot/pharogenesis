mapName: nameString password: pwdString to: aPerson
	"Insert/remove the username:password combination into/from the users Dictionary.  *** Use this method to add or delete users!  If you ask for the authorizer and talk to it, the change will not be recorded on the disk! ***   We use encoding per RFC1421."

	authorizer mapName: nameString password: pwdString to: aPerson.
	self authorizer: authorizer.	"force it to be written to the disk"