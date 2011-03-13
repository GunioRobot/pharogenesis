discardMorphic
	"Discard Morphic."

	self halt: 'not yet complete; leaves many obsolete classes'.
	SystemOrganization removeCategoriesMatching: 'User Objects'.
	SystemOrganization removeCategoriesMatching: '*EToy*'.
	SystemOrganization removeCategoriesMatching: 'Morphic*'.

