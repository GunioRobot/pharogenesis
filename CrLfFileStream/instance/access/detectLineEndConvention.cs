detectLineEndConvention
	"Detect the line end convention used in this stream. The result may be either #cr, #lf or #crlf."
	| char numRead pos |
	self isBinary ifTrue: [^ self error: 'Line end conventions are not used on binary streams'].
	lineEndConvention _ LineEndDefault.
	"Default if nothing else found"
	numRead _ 0.
	pos _ super position.
	[super atEnd not and: [numRead < LookAheadCount]]
		whileTrue: 
			[char _ super next.
			char = Lf
				ifTrue: 
					[super position: pos.
					^ lineEndConvention _ #lf].
			char = Cr
				ifTrue: 
					[super peek = Lf
						ifTrue: [lineEndConvention _ #crlf]
						ifFalse: [lineEndConvention _ #cr].
					super position: pos.
					^ lineEndConvention].
			numRead _ numRead + 1].
	super position: pos.
	^ lineEndConvention