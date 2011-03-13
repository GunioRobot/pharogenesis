setUpHierarchy
	ta := self createTraitNamed: #TA
				uses: { }.
	tb := self createTraitNamed: #TB
				uses: { }.
	tc := self createTraitNamed: #TC uses: tb.
	ca := self 
				createClassNamed: #CA
				superclass: ProtoObject
				uses: { }.
	cb := self 
				createClassNamed: #CB
				superclass: ca
				uses: ta + tb.
	cc := self 
				createClassNamed: #CC
				superclass: cb
				uses: tb.
	cd := self 
				createClassNamed: #CD
				superclass: cc
				uses: { }.
	ce := self 
				createClassNamed: #CE
				superclass: cc
				uses: { }.
	cf := self 
				createClassNamed: #CF
				superclass: cb
				uses: { }.
	cg := self 
				createClassNamed: #CG
				superclass: cf
				uses: { }.
	ch := self 
				createClassNamed: #CH
				superclass: ca
				uses: { ta }.
	ci := self 
				createClassNamed: #CI
				superclass: ch
				uses: { }.

	ca compile: 'mca ^self ssca'.
	cb compile: 'mca ^3'.
	cb compile: 'mcb super mca'.
	cc compile: 'mcb ^3'.
	cc compile: 'mcb ^self sscc'.
