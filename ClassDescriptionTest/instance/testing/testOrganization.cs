testOrganization

	| aClassOrganizer |

	aClassOrganizer := ClassDescription organization.
	self should: [aClassOrganizer isKindOf: ClassOrganizer].