removeVersion
	| package |
	self anyPackageSelected ifFalse: [ ^self ].
	self acceptFields.

	package _ self selectedPackage.

	(self confirm: ('Delete ', 	package printString, '?')) ifFalse: [
		^self ].

	self sendMessage: (UMRemovePackage username: username password: password packageName: package name packageVersion: package version).
