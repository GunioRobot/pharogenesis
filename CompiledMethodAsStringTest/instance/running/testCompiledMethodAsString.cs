testCompiledMethodAsString
     "self debug: #testCompiledMethodAsString" 

	self shouldnt: [CompiledMethod allInstances first  asString] raise: Error