fillBuffer
	| byte |
	[jsBitCount <= 16] whileTrue:[
		jsPosition < jsReadLimit ifFalse:[^jsBitCount].
		byte _ jsCollection at: jsPosition.
		jsPosition _ jsPosition + 1.
		byte = 16rFF ifTrue:["peek for 00"
			((jsPosition < jsReadLimit) and:[(jsCollection at: jsPosition) = 16r00]) ifFalse:[
				jsPosition _ jsPosition - 1.
				^jsBitCount].
			jsPosition _ jsPosition + 1].
		jsBitBuffer _ (jsBitBuffer bitShift: 8) bitOr: byte.
		jsBitCount _ jsBitCount + 8].
	^jsBitCount