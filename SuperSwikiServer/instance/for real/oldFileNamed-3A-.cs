oldFileNamed: aName

	| answer |

	answer _ self sendToSwikiProjectServer: {
		'action: readnamedfile'.
		'projectname: ',aName convertToSuperSwikiServerString.
	}.
	(answer beginsWith: 'OK') ifFalse: [ ^nil].
	^(SwikiPseudoFileStream with: (answer allButFirst: 3))
		reset;
		directory: self;
		localName: aName convertToSuperSwikiServerString;
		yourself
