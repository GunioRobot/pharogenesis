testReshapeClass
	"see if reshaping classes works"
	"self run: #testReshapeClass"

	| testInstance testClass testMeta newClass newMeta |
	testClass _ Smalltalk at: #ClassBuilderTestClass.
	testMeta _ testClass class.
	testInstance _ testClass new.
	testInstance var1: 42.
	testInstance var2: 'hello'.
	newClass _ self
				createClassNamed: #ClassBuilderTestClass
				superClass: Object
				instanceVariables: 'foo var1 bar var2 mumble'.
	newMeta _ newClass class.
	"test transparency of mapping"
	self assert: testInstance var1 = 42.
	self assert: testInstance var2 = 'hello'.
	self assert: (testInstance instVarAt: 1) isNil.
	self assert: (testInstance instVarAt: 2)
			= 42.
	self assert: (testInstance instVarAt: 3) isNil.
	self assert: (testInstance instVarAt: 4)
			= 'hello'.
	self assert: (testInstance instVarAt: 5) isNil.
	"test transparency of reshapes"
	self assert: testInstance class == newClass.
	self assert: testClass == newClass.
	self assert: testMeta == newMeta