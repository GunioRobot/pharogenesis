setUp

	| classBuilderTestClass classBuilderTestSubClass |
	self createClassNamed: #ClassBuilderTestClass superClass: Object instanceVariables: 'var1 var2'.
	classBuilderTestClass := (Smalltalk at: #ClassBuilderTestClass).
	classBuilderTestClass compile: 'var1	^var1'.
	classBuilderTestClass compile: 'var1: object	var1 := object'.
	classBuilderTestClass compile: 'var2	^var2'.
	classBuilderTestClass compile: 'var2: object	var2 := object'.

	self createClassNamed: #ClassBuilderTestSubClass superClass: classBuilderTestClass instanceVariables: 'var3 var4'.
	classBuilderTestSubClass := (Smalltalk at: #ClassBuilderTestSubClass).
	classBuilderTestSubClass compile: 'var3	^var3'.
	classBuilderTestSubClass compile: 'var3: object	var3 := object'.
	classBuilderTestSubClass compile: 'var4	^var4'.
	classBuilderTestSubClass compile: 'var4: object	var4 := object'.