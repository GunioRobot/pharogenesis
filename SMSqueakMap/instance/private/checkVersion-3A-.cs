checkVersion: string
	"Check the content for a SqueakMap version conflict notification.
	Return true if no conflict is reported, otherwise ask user if we
	should upgrade SqueakMap using the bootstrap method."

	(string beginsWith: 'Server version:')
		ifTrue:[(self confirm: ('The SqueakMap master server is running another version (', (string last: (string size - 15)), ') than the client (', SMSqueakMap version, ').
You need to upgrade the SqueakMap package, would you like to do that now?'))
			ifTrue: [self class bootStrap. ^false]
			ifFalse: [^false]
	].
	^true