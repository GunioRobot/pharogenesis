testTheMetaClass
	"self run: #testTheMetaClass"

	self assert: Class class theMetaClass == Class class.
	self assert: Class theMetaClass == Class class.