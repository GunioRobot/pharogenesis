name: aString traitComposition: aComposition methodDict: aMethodDict localSelectors: aSet organization: aClassOrganization

	"Used by copy"
	
	self name: aString.
	localSelectors _ aSet.
	methodDict _ aMethodDict.
	traitComposition _ aComposition.
	self organization: aClassOrganization
	
	