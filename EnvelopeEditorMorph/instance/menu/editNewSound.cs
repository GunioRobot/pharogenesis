editNewSound
	| known i |
	known _ AbstractSound soundNames.
	i _ 0.
	[soundName _ 'unnamed' , i printString.
	known includes: soundName]
		whileTrue: [i _ 1+1].
	soundName _ soundName.
	self editSound: FMSound default copy