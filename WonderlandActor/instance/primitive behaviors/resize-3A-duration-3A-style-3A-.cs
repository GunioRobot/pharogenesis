resize: amount duration: aDuration style: aStyle
	"Resize the object by the specified amount over the specified duration using the specified animation style."

	"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyNumberOrTriple: amount ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , '  because ', msg.
				^ nil ].

	(amount isNumber)
		ifTrue: [ ^ (self resizeTopToBottom: amount leftToRight: amount frontToBack: amount
						duration: 1.0
						style: gently). ]
		ifFalse: [  ^ (self resizeTopToBottom: (amount at: 2)
						leftToRight: (amount at: 1)
						frontToBack: (amount at: 3)
						duration: 1.0
						style: gently). ].
