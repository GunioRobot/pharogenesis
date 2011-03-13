pictureForIPAddress: ipString

	| senderMorphs |

	senderMorphs := EToySenderMorph allInstances select: [ :x | 
		x userPicture notNil and: [x ipAddress = ipString]
	].
	senderMorphs isEmpty ifTrue: [^nil].
	^senderMorphs first userPicture

