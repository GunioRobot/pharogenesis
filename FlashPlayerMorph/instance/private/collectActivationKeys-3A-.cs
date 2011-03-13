collectActivationKeys: frame
	"Note: Must only be called after a frame has been completed"
	| vis lastKey |
	vis := Array new: frame.
	vis atAllPut: #().
	lastKey := activationKeys size.
	vis replaceFrom: 1 to: lastKey with: activationKeys startingAt: 1.
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
			m activationKeys do:[:key|
				key > lastKey ifTrue:[
					vis at: key put: ((vis at: key) copyWith: m)
				].
			].
		].
	].
	^vis