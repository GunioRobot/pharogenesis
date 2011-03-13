tryIcons: anArray
	| selector |
	selector := anArray detect: [:ea | self respondsTo: ea] ifNone: [self blankIcon].
	^ MenuIcons perform: selector