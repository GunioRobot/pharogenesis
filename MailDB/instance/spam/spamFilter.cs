spamFilter
	^ Preferences celesteDespam ifFalse: [nil] ifTrue: [(spamFilterFile ifNil: [spamFilterFile _ SpamFilterFile openOn: rootFilename, '.spamFilter']) filter]