isFailure: cls sel: selector 
	"self new isKnowProblem: PNMReaderWriter sel: #nextImage"
	"#((PNMReadWriter nextImage)) includes: {PNMReadWriter
	name asSymbol . #nextImage}."
	^(#(#DoIt #DoItIn:) includes: selector)
	   or: [self decompilerFailures includes: {cls name asSymbol. selector}]