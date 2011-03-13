superUser: anAccount
	superUser ifNotNil: [
		accounts remove: superUser ].
	superUser := anAccount.
	accounts add: superUser.
	