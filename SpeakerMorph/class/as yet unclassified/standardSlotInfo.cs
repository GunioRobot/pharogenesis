standardSlotInfo
	"Answer a list of arrays which characterize etoy slots borne by this kind of morph -- in addition to those already defined by superclasses.  Implementors of this method are statically polled to contribute this information when the scripting system reinitializes its scripting info, which typically only happens after a structural change."

	^ #((conePosition 	number		readWrite	getConePosition		setConePosition:))
