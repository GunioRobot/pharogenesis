parseNextMarker

	| byte discardedBytes |
	discardedBytes _ 0.
	[(byte _ self next) = 16rFF] whileFalse: [ self debug. discardedBytes _ discardedBytes + 1].	
	[[(byte _ self next) = 16rFF] whileTrue. byte = 16r00] whileTrue:
		[discardedBytes _ discardedBytes + 2].
	discardedBytes > 0 ifTrue: [self notify: 'warning: extraneous data discarded'].
	self perform:
		(JFIFMarkerParser
			at: byte
			ifAbsent:
				[(self okToIgnoreMarker: byte)
					ifTrue: [#skipMarker]
					ifFalse: [self error: 'marker ', byte hex , ' cannot be handled']])