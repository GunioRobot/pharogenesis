setStream: aStream
	"Initialize me. "

	super setStream: aStream.
	steady _ Set new.
	#(Array Dictionary Association String SmallInteger) do: [:sym |
		steady add: (Smalltalk at: sym)].
		"These must stay constant.  When structures read in, then things can change."
	reshaped _ Dictionary new.	
		"(old class name -> method selector to fill in data for version to version)"
	renamed _ Dictionary new.
		"(old class name symbol -> new class name)"
