string: aString 
	string _ aString.
	chars = 0
		ifTrue: 
			[chars _ string size.
			self chars: chars].
	self stringToLed