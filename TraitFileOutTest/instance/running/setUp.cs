setUp
	super setUp.
	SystemOrganization addCategory: self categoryName.
	
	td _ self createTraitNamed: #TD uses: {}.		
	td compile: 'd' classified: #cat1.
	tc _ self createTraitNamed: #TC uses: td.		
	tc compile: 'c' classified: #cat1.
	tb _ self createTraitNamed: #TB uses: td.		
	tb compile: 'b' classified: #cat1.
	ta _ self createTraitNamed: #TA uses: tb + tc @ {#cc->#c} - {#c}.
	ta compile: 'a' classified: #cat1.
	
	ca _ self createClassNamed: #CA superclass: Object uses: {}.
	ca compile: 'ca' classified: #cat1.
	cb _ self createClassNamed: #CB superclass: ca uses: ta.
	cb compile: 'cb' classified: #cat1.
	
	"make the class of cb also use tc:"
	cb class uses: ta classTrait + tc instanceVariableNames: ''.