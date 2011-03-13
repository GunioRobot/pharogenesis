setSender: s receiver: r method: m arguments: args 
	"Create the receiver's initial state."

	sender _ s.
	receiver _ r.
	method _ m.
	receiverMap _ nil.
	pc _ method initialPC.
	self stackp: method numTemps.
	1 to: args size do: [:i | self at: i put: (args at: i)]