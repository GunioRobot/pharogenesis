testAccessingClassHierarchy
	"self run: #testAccessingClassHierarchy"
	| clsRoot clsA clsB clsC1 clsC2 |
	clsRoot _ self createClassNamed: #Root.
	clsA _ self createClassNamed: #A superClass: clsRoot.
	clsB _ self createClassNamed: #B superClass: clsA.
	clsC1 _ self createClassNamed: #C1 superClass: clsB.
	clsC2 _ self createClassNamed: #C2 superClass: clsB.
	"--------"
	self assert: clsRoot subclasses size = 1.
	self
		assert: (clsRoot subclasses includes: clsA).
	self assert: clsB subclasses size = 2.
	self
		assert: (clsB subclasses
				includesAllOf: (Array with: clsC1 with: clsC2)).
	self assert: clsC1 subclasses isEmpty.
	"--------"
	self assert: clsRoot allSubclasses size = 4.
	self
		assert: (clsRoot allSubclasses
				includesAllOf: (Array
						with: clsA
						with: clsB
						with: clsC1
						with: clsC2)).
	"--------"
	self assert: clsRoot withAllSubclasses size = 5.	
	self
		assert: (clsRoot withAllSubclasses
				includesAllOf: (Array
						with: clsA
						with: clsB
						with: clsC1
						with: clsC2
						with: clsRoot)).
