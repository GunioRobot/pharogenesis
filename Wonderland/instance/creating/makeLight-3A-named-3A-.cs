makeLight: lightType named: aString
	"Create a light of the specified type and add it to the Wonderland"

	| newClass theLight name |

	"Make sure the user gave us a type of light"
	[ WonderlandVerifier VerifyLight: lightType ]
		ifError: [ :msg :rcvr |
			self reportErrorToUser:
				'Squeak could not determine the type of light to create because ', msg.
			^ nil ].

	"The user gave us a valid type type, so proceed"
	(lightType = ambient)
		ifTrue: [ newClass _ WonderlandAmbientLight newUniqueClassInstVars: ''
									classInstVars: ''.
					theLight _ newClass createFor: self. ]
		ifFalse: [ (lightType = positional)
			ifTrue: [ newClass _ WonderlandPositionalLight newUniqueClassInstVars: ''
										classInstVars: ''.
					theLight _ newClass createFor: self. ]
			ifFalse: [ (lightType = directional)
				ifTrue: [ newClass _ WonderlandDirectionalLight newUniqueClassInstVars: ''
										classInstVars: ''.
						theLight _ newClass createFor: self. ]
				ifFalse: [ newClass _ WonderlandSpotLight newUniqueClassInstVars: ''
										classInstVars: ''.
						theLight _ newClass createFor: self. ]
					]
				].

	actorClassList addLast: newClass.
	name _ self uniqueNameFrom: (aString ifNil:['light']).
	theLight setName: name.
	myNamespace at: name put: theLight.
	scriptEditor updateActorBrowser.

	lightList addLast: theLight.

	^ theLight.
