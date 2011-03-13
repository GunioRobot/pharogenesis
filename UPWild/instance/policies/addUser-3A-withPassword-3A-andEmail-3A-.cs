addUser: username withPassword: password  andEmail: email
	| newAccount |
	(accounts anySatisfy: [ :acc | acc username = username]) ifTrue: [
		"already an account here"
		^UPolicyResponse denied: 'account already exists' ].

	superUser ifNotNil: [
		superUser username = username ifTrue: [
			"cannot create an account with the superuser's name"
			^UPolicyResponse denied: 'same account name as the superuser' ] ].
		
	(self class isReasonableUsername: username) ifFalse: [
		^UPolicyResponse denied: 'invalid account name' ].
	
	newAccount _ UAccount new.
	newAccount username: username.
	newAccount password: password.
	newAccount email: email.
	
	accounts add: newAccount.
	^UPolicyResponse allowed