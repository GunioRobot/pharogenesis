mailPassword: randomPass for: anAccount
	"Change the password to a random generated one
	and mail it to the holder of the account."

	self mail: anAccount subject: 'New password at SqueakMap!' message:
'Hi!
An extra random password has been added for the account held by "', anAccount name, '":
"', randomPass, '"

You can login to SqueakMap at:

', MasterServer, '/login

The regular password still works, so if it was not you who requested this extra
random password you can safely just delete this email.

This extra password will stop working when you change your regular password.

'