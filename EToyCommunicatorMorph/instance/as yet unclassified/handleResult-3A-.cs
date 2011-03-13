handleResult: aDictionary

	| m |

	aDictionary at: #commFlash ifPresent: [ :ignore | ^self flashIndicator: #communicating].
	self resetIndicator: #communicating.
	m _ aDictionary at: #message ifAbsent: ['unknown message'].
	m = 'OK' ifTrue: [^self].
	self reportError: m