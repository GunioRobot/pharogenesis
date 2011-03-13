nameForIPAddress: ipString

	| senderMorphs |

	senderMorphs _ EToySenderMorph allInstances select: [ :x | 
		x userName notNil and: [x ipAddress = ipString]
	].
	senderMorphs isEmpty ifTrue: [^nil].
	^senderMorphs first userName

