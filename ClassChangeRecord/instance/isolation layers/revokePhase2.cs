revokePhase2

	revertable ifFalse: [^ self].

	"Replace the original organization (and comment)."
	thisOrganization _ self realClass organization.
	self realClass organization: priorOrganization.
	inForce _ false.
