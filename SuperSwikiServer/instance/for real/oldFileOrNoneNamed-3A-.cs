oldFileOrNoneNamed: fullName

	| answer aName |

	self flag: #bob.		"fix this up for full names"

	aName _ fullName.
	answer _ self sendToSwikiProjectServer: {
		'action: readnamedfile'.
		'projectname: ',(self localNameFor: aName).
	}.
	(answer beginsWith: 'OK') ifFalse: [^nil].
	^(SwikiPseudoFileStream with: (answer allButFirst: 3))
		reset;
		directory: self;
		localName: aName;
		yourself
