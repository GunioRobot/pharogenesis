windowWithLabel: aLabel
	"Answer a SystemWindow associated with the receiver, with appropriate border characteristics"

	| window |
	(window _ SystemWindow labelled: aLabel) model: self.
	"window borderWidth: 1; borderColor: self defaultBackgroundColor darker."
	^ window
