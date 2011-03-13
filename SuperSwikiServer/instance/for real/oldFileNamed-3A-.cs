oldFileNamed: aName

	| answer |

	answer _ self sendToSwikiProjectServer: {
		'action: readnamedfile'.
		'projectname: ',aName convertToEncoding: self encodingName.
	}.
	(answer beginsWith: 'OK') ifFalse: [ ^nil].
	^(SwikiPseudoFileStream with: (answer allButFirst: 3))
		reset;
		directory: self;
		localName: (aName convertToEncoding: self encodingName);
		yourself
