findOrCreatePublisher: pub password: password package: aPackage
	"Find or create an account. Password will be the first one."

	| email name account |
	email _ SMUtilities stripEmailFrom: pub.
	name _ SMUtilities stripNameFrom: pub.
	account _ self accountForEmail: email.
	account ifNil: ["none found, try searching on name too..."
		account _ self accountForName: name].
	account
		ifNotNil: [account addObject: aPackage]
		ifNil: ["Ok, create it"	
			account _ self newAccount
					name: name;
					email: email;
					password: password.
			account addObject: aPackage.
			self newObject: account.
			account].
	^account
	
