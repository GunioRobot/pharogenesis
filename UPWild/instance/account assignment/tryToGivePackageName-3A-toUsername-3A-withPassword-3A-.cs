tryToGivePackageName: packageName toUsername: username  withPassword: password
	| account |
	(self class isReasonablePackageName: packageName) ifFalse: [
		^UPolicyResponse denied: 'invalid package name' ].
	
	account _ self findAccount: username withPassword: password.
	account ifNil: [ ^UPolicyResponse denied: 'incorrect password or no such user' ].

	account == superUser ifTrue: [
		^UPolicyResponse allowed ].

	(account ownsPackageName: packageName) ifTrue: [
		^UPolicyResponse allowed ].
	
	(accounts anySatisfy: [ :acc | acc ownsPackageName: packageName ]) ifTrue: [
		^UPolicyResponse denied: 'package is owned by another' ].
	
	account addPackageName: packageName.
	^UPolicyResponse allowed