changeUser: username withPassword: password toHavePassword: newPassword andNewEmail: newEmail
	| account |
	account _ self findAccount: username withPassword: password.
	account ifNil: [ ^UPolicyResponse denied: 'username not present or password does not match' ].
	
	newPassword isEmpty ifFalse: [account password: newPassword ].
	newEmail isEmpty ifFalse: [account email: newEmail ].
	^UPolicyResponse allowed