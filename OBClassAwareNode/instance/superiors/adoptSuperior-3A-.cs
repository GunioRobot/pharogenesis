adoptSuperior: other 
	| descent |
	descent := self theClass allSuperclasses reversed.
	(descent indexOf: other theClass) > (descent indexOf: self superiorClass) 
		ifTrue: [superior := other]