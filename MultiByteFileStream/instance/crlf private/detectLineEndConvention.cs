detectLineEndConvention
	"Detect the line end convention used in this stream. The result may be either #cr, #lf or #crlf."
	| char numRead state |
	self isBinary ifTrue: [^ self error: 'Line end conventions are not used on binary streams'].
	self wantsLineEndConversion ifFalse: [^ lineEndConvention _ nil.].
	self closed ifTrue: [^ lineEndConvention _ LineEndDefault.].

	"Default if nothing else found"
	numRead _ 0.
	state _ converter saveStateOf: self.
	lineEndConvention _ nil.
	[super atEnd not and: [numRead < LookAheadCount]]
		whileTrue: 
			[char _ self next.
			char = Lf
				ifTrue: 
					[converter restoreStateOf: self with: state.
					^ lineEndConvention _ #lf].
			char = Cr
				ifTrue: 
					[self peek = Lf
						ifTrue: [lineEndConvention _ #crlf]
						ifFalse: [lineEndConvention _ #cr].
					converter restoreStateOf: self with: state.
					^ lineEndConvention].
			numRead _ numRead + 1].
	converter restoreStateOf: self with: state.
	^ lineEndConvention _ LineEndDefault.
