packageWrapperList
	"Return the list with each element wrapped so that it
	can be used in a SimpleHierarchicalListMorph."

	^self packageList collect: [:e | SMPackageWrapper with: e]