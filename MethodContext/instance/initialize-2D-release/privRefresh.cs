privRefresh
	"Reinitialize the receiver so that it is in the state it was at its creation."

	pc _ method initialPC.
	self stackp: method numTemps.
	method numArgs+1 to: method numTemps
		do: [:i | self tempAt: i put: nil]