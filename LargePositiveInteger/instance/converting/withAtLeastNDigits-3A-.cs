withAtLeastNDigits: desiredLength

	| new |

	self size >= desiredLength ifTrue: [^self].
	new _ self class new: desiredLength.
	new
		replaceFrom: 1 
		to: self size 
		with: self 
		startingAt: 1.
	^new