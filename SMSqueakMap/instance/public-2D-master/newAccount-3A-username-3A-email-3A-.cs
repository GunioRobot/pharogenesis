newAccount: name username: username email: email
	"Create an account. Checking for previous account should already have been done.
	To add the account to the map, use SMSqueakMap>>addObject:"

	| account |
	account := self newAccount
					name: name;
					initials: username;
					email: email.
	^account
	
