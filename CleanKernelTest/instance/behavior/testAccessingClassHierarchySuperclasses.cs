testAccessingClassHierarchySuperclasses
	"self run: #testAccessingClassHierarchySuperclasses"
	| clsRoot clsA clsB clsC1 clsC2 |
	clsRoot _ self createClassNamed: #Root.
	clsA _ self createClassNamed: #A superClass: clsRoot.
	clsB _ self createClassNamed: #B superClass: clsA.
	clsC1 _ self createClassNamed: #C1 superClass: clsB.
	clsC2 _ self createClassNamed: #C2 superClass: clsB.
	"--------"
	self assert: clsC2 superclass == clsB.
	self
		assert: (clsC2 allSuperclasses includes: clsA).
	self assert: clsC2 allSuperclasses size = 5.
	self
		assert: (clsC2 allSuperclasses
				includesAllOf: (Array
						with: clsB
						with: clsA
						with: clsRoot
						with: Object
						with: ProtoObject)).
	"--------"
	self assert: clsC1 superclass == clsB.
	self
		assert: (clsC1 allSuperclasses includes: clsA).
	self assert: clsC1 allSuperclasses size = 5.
	self
		assert: (clsC1 allSuperclasses
				includesAllOf: (Array
						with: clsB
						with: clsA
						with: clsRoot
						with: Object
						with: ProtoObject)).
	"--------"
	self assert: clsC2 withAllSuperclasses size = (clsC2 allSuperclasses size + 1).
	self
		assert: (clsC2 withAllSuperclasses includesAllOf: clsC2 allSuperclasses).
	self
		assert: (clsC2 withAllSuperclasses includes: clsC2).
	"--------"
	self assert: clsC1 withAllSuperclasses size = (clsC1 allSuperclasses size + 1).
	self
		assert: (clsC1 withAllSuperclasses includesAllOf: clsC1 allSuperclasses).
	self
		assert: (clsC1 withAllSuperclasses includes: clsC1)