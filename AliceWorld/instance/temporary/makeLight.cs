makeLight
	"Create a light of the specified type and add it to the Wonderland"

	| theLight lightType name |

	lightType _ positional.

	"Make sure the user gave us a type of light"
	[ WonderlandVerifier VerifyLight: lightType ]
		ifError: [ :msg :rcvr |
			self reportErrorToUser:
				'Squeak could not determine the type of light to create because ', msg.
			^ nil ].

	"The user gave us a valid type type, so proceed"
	(lightType = ambient)
		ifTrue: [ theLight _ WonderlandAmbientLight createFor: self. ]
		ifFalse: [ (lightType = positional)
			ifTrue: [ theLight _ WonderlandPositionalLight createFor: self. ]
			ifFalse: [ (lightType = directional)
				ifTrue: [ theLight _ WonderlandDirectionalLight createFor: self. ]
				ifFalse: [ theLight _ WonderlandSpotLight createFor: self. ]
					]
				].

	name _ self uniqueNameFrom: 'light'.
	theLight setName: name.
	myNamespace at: name put: theLight.

	lightList addLast: theLight.

	^ theLight.
