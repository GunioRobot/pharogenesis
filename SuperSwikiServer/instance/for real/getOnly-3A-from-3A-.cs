getOnly: numberOfBytes from: aName

	| answer |

	answer _ self sendToSwikiProjectServer: {
		'action: readnamedfile'.
		'projectname: ',aName.
		'bytestoread: ',numberOfBytes printString.
	}.
	(answer beginsWith: 'OK') ifFalse: [ ^nil].
	^answer allButFirst: 3
