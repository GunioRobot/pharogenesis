isFailure: cls sel: selector 
	"self new isKnowProblem: PNMReaderWriter sel: #nextImage"
	"#((PNMReadWriter nextImage)) includes: {PNMReadWriter
	name asSymbol . #nextImage}."
	^ self decompilerFailures includes: {cls name asSymbol. selector}