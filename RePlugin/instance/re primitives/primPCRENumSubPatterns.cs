primPCRENumSubPatterns

"<rcvr primPCRENumSubPatterns>, where rcvr is an object with instance variables:

	'patternStr compileFlags pcrePtr extraPtr errorStr errorOffset matchFlags'	

Return the number of subpatterns captured by the compiled pattern."

	self export: true.
	
	"Load Parameters"
	self loadRcvrFromStackAt: 0.
	"Load Instance Variables"
	pcrePtr _ self rcvrPCREBufferPtr.
	interpreterProxy pop: 1; pushInteger: (self cCode: 'pcre_info((pcre *)pcrePtr, NULL, NULL)').
