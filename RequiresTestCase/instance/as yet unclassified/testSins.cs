testSins
	| caa cab cac cad |
	caa := self 
				createClassNamed: #CAA
				superclass: ProtoObject
				uses: { }.
	caa superclass: nil.
	cab := self 
				createClassNamed: #CAB
				superclass: caa
				uses: {}.
	cac := self 
				createClassNamed: #CAC
				superclass: cab
				uses: {}.
	cad := self 
				createClassNamed: #CAD
				superclass: cac
				uses: { }.

	caa compile: 'ma self foo'.
	caa compile: 'md self explicitRequirement'.
	cac compile: 'mb self bar'.
	self noteInterestsFor: cad.
	self assert: (cad requiredSelectors = (Set withAll: #(foo bar md))).
	cab compile: 'mc ^3'.
	self assert: (cad requiredSelectors = (Set withAll: #(foo bar md))).
	self loseInterestsFor: cad.