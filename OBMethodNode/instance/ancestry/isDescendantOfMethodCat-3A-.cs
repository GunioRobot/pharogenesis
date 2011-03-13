isDescendantOfMethodCat: aMethodCatNode
	^ (self theClass organization categoryOfElement: self selector) = aMethodCatNode name