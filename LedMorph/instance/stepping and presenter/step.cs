step
	(flash or: [flashing])
		ifTrue: 
			[flashing _ flashing not.
			self highlighted: flashing].
	scroller ifNil: [scroller _ 1].
	chars ifNil: [^ self].
	scroller + chars < (string size + 1)
		ifTrue: 
			[scroller _ scroller + 1.
			self stringToLed]
		ifFalse: [scrollLoop ifTrue: [scroller _ 1]]