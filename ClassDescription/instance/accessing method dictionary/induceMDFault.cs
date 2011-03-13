induceMDFault
	"Stache a copy of the methodDict in the organization slot (hack!),
	and set the methodDict to nil.  This will induce an MD fault on any message send.
	See: ClassDescription>>recoverFromMDFault
	and ImageSegment>>discoverActiveClasses."

	organization _ Array with: methodDict with: organization.
	methodDict _ nil.
	self flushCache