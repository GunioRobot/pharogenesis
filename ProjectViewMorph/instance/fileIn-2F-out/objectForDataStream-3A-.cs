objectForDataStream: refStrm
	
	| copy |

	1 = 1 ifTrue: [^self].		"this didn't really work"

	copy _ self copy lastProjectThumbnail: nil.
	"refStrm replace: self with: copy."
	^copy
