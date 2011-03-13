traitComposition: aComposition methodDict: aMethodDict localSelectors: aSet organization: aClassOrganization

	"Used by copy of Trait"

	localSelectors _ aSet.
	methodDict _ aMethodDict.
	traitComposition _ aComposition.
	self organization: aClassOrganization