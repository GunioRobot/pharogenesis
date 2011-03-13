isStructuredField: aString

	| fName |
	fName _ aString copyUpTo: $:.
	('Resent' sameAs: (fName copyUpTo: $-))
		ifTrue: [fName _ fName copyFrom: 8 to: fName size].
	^#('Sender' 'From' 'Reply-To' 'To' 'cc' 'bcc') anySatisfy: [:each | fName sameAs: each]