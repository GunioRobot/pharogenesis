windowWithLabel: aLabel
	"Answer a SystemWindow associated with the receiver," 

	^ (SystemWindow labelled: aLabel) model: self
