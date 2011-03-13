setUp
	super setUp.
	t7 := self createTraitNamed: #T7
				uses: { }.
	t7 compile: 'm13 ^self m12' classified: #cat3.
	t8 := self createTraitNamed: #T8
				uses: { (t7 - { #m13 }) }.
	t9 := self createTraitNamed: #T9
				uses: { }.
	t9 compile: 'm13 ^self m12' classified: #cat3.
	t9 compile: 'm12 ^3' classified: #cat3.
	t10 := self createTraitNamed: #T10
				uses: { (t9 - { #m12 }) }.

	t11 := self createTraitNamed: #T11
				uses: { (t9 @ { (#m11 -> #m12) } - { #m12 }) }.

	c9 := self 
			createClassNamed: #C9
			superclass: ProtoObject
			uses: t7.

	
	c10 := self 
			createClassNamed: #C10
			superclass: ProtoObject
			uses: t7.
	c10 compile: 'm12 ^3'.

	c11 := self createClassNamed: #C11
			superclass: ProtoObject
			uses: {}.
	c11 compile: 'm12 ^3'.
	c12 := self createClassNamed: #C12
			superclass: c11
			uses: {t7}.
