detectLineEndConvention
	"Detect the line end convention used in this stream. The result may be either #cr, #lf or #crlf."
	| char numRead state |
	self isBinary ifTrue: [^ self error: 'Line end conventions are not used on binary streams'].
	self wantsLineEndConversion ifFalse: [^ lineEndConvention := nil.].
	self closed ifTrue: [^ lineEndConvention := LineEndDefault.].

	"Default if nothing else found"
	numRead := 0.
	state := converter saveStateOf: self.
	lineEndConvention := nil.
	[super atEnd not and: [numRead < LookAheadCount]]
		whileTrue: 
			[char := self next.
			char = Lf
				ifTrue: 
					[converter restoreStateOf: self with: state.
					^ lineEndConvention := #lf].
			char = Cr
				ifTrue: 
					[self peek = Lf
						ifTrue: [lineEndConvention := #crlf]
						ifFalse: [lineEndConvention := #cr].
					converter restoreStateOf: self with: state.
					^ lineEndConvention].
			numRead := numRead + 1].
	converter restoreStateOf: self with: state.
	^ lineEndConvention := LineEndDefault.
