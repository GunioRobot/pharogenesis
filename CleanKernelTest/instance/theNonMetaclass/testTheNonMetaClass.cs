testTheNonMetaClass
	"self run: #testTheNonMetaClass"

	self assert: Class class theNonMetaClass == Class.
	self assert: Class theNonMetaClass == Class.