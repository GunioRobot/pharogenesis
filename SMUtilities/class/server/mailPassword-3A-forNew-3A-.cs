mailPassword: aPassword forNew: anAccount
	"Mail the password to the person who just registered the account."

	self mail: anAccount subject: 'Your new account at SqueakMap!' message:
'Hi!
You or someone else has registered an account on SqueakMap. You can login to it using this link:

',
MasterServer, '/autologin?u=', anAccount initials, '&p=', aPassword,
'

If it was not you who performed this registration you can safely just delete this email.

'