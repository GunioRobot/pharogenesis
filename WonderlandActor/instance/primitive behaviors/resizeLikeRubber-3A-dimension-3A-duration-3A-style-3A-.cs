resizeLikeRubber: amount dimension: aDimension duration: aDuration style: aStyle
	"Resizes the object using a volume preserving resize"

	| x y z |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDimension: aDimension ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine along which dimension to resize ' , myName , '  because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: amount ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , '  because ', msg.
			^ nil ].

	(aDimension = leftToRight)
		ifTrue: [
					x _ amount.
					y _ 1 / (amount sqrt).
					z _ 1 / (amount sqrt).
				]
		ifFalse: [ (aDimension = topToBottom)
				ifTrue: [
							x _ 1 / (amount sqrt).
							y _ amount.
							z _ 1 / (amount sqrt).
						]
				ifFalse: [ (aDimension = frontToBack)
						ifTrue: [
									x _ 1 / (amount sqrt).
									y _ 1 / (amount sqrt).
									z _ amount.
								].
						].
				].

	^ self resizeTopToBottom: y leftToRight: x frontToBack: z duration: aDuration style: aStyle.

