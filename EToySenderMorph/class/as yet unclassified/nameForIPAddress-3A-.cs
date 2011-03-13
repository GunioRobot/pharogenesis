nameForIPAddress: ipString

	| senderMorphs |

	senderMorphs := EToySenderMorph allInstances select: [ :x | 
		x userName notNil and: [x ipAddress = ipString]
	].
	senderMorphs isEmpty ifTrue: [^nil].
	^senderMorphs first userName

