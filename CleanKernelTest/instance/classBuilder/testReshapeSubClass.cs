testReshapeSubClass
	"self run: #testReshapeSubClass"
	"self debug: #testReshapeSubClass"

	| testInstance testClass testMeta |

	testClass _ Smalltalk at: #ClassBuilderTestSubClass.
	testMeta _ testClass class.
	testInstance _ testClass new.
	testInstance var1: 42.
	testInstance var2: 'hello'.
	testInstance var3: 'foo'.
	testInstance var4: #bar.
	self
		createClassNamed: #ClassBuilderTestClass
		superClass: Object
		instanceVariables: 'var1 foo var2 bar mumble '.
	self assert: testInstance var1 = 42.
	self assert: testInstance var2 = 'hello'.
	self assert: testInstance var3 = 'foo'.
	self assert: testInstance var4 = #bar.
	self assert: (testInstance instVarAt: 1)
			= 42.
	self assert: (testInstance instVarAt: 2) isNil.
	self assert: (testInstance instVarAt: 3)
			= 'hello'.
	self assert: (testInstance instVarAt: 4) isNil.
	self assert: (testInstance instVarAt: 5) isNil.
	self assert: (testInstance instVarAt: 6)
			= 'foo'.
	self assert: (testInstance instVarAt: 7)
			= #bar.
	self assert: testInstance class == (Smalltalk at: #ClassBuilderTestSubClass).
	self assert: testClass == (Smalltalk at: #ClassBuilderTestSubClass).
	self assert: testMeta == (Smalltalk at: #ClassBuilderTestSubClass) class