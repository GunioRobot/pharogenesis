primPCREExecfromto

"<rcvr primPCREExec: searchObject> from: fromInteger to: toInteger>, where rcvr is an object with instance variables:

	'patternStr compileFlags pcrePtr extraPtr errorStr errorOffset matchFlags'	

Apply the regular expression (stored in <pcrePtr> and <extratr>, generated from calls to primPCRECompile), to smalltalk String searchObject using <matchOptions>, beginning at offset <fromInteger> and continuing until offset <toInteger>.  If there is no match, answer nil.  Otherwise answer a ByteArray of offsets representing the results of the match."

	| searchObject searchBuffer length  result matchSpacePtr matchSpaceSize fromInteger toInteger |
	self export: true.
	self var:#searchBuffer	declareC: 'char *searchBuffer'.
	self var:#fromInteger declareC: 'int fromInteger'.
	self var:#toInteger declareC: 'int toInteger'.
	self var:#matchSpacePtr	declareC: 'int *matchSpacePtr'.
	self var:#result			declareC: 'int result'.
	
	"Load Parameters"
	toInteger _ interpreterProxy stackIntegerValue: 0.
	fromInteger _ interpreterProxy stackIntegerValue: 1.
	searchObject _ interpreterProxy stackObjectValue: 2.	
	searchBuffer _ interpreterProxy arrayValueOf: searchObject.
	length _ interpreterProxy byteSizeOf: searchObject.
	self loadRcvrFromStackAt: 3.

	"Validate parameters"
	interpreterProxy success: (1 <= fromInteger).
	interpreterProxy success: (toInteger<=length).
	fromInteger _ fromInteger - 1. "Smalltalk offsets are 1-based"
	interpreterProxy success: (fromInteger<=toInteger).

	"adjust length, searchBuffer"
	length _ toInteger - fromInteger.
	searchBuffer _ searchBuffer + fromInteger.

	"Load Instance Variables"
	pcrePtr _ self rcvrPCREBufferPtr.
	extraPtr _ self rcvrExtraPtr.
	matchFlags _ self rcvrMatchFlags.
	matchSpacePtr _ self rcvrMatchSpacePtr.
	matchSpaceSize _ self rcvrMatchSpaceSize.
	interpreterProxy failed ifTrue:[^ nil].
	
	result _ self 
		cCode: 'pcre_exec((pcre *)pcrePtr, (pcre_extra *)extraPtr, 
				searchBuffer, length, 0, matchFlags, matchSpacePtr, matchSpaceSize)'.
	interpreterProxy pop: 2; pushInteger: result.

	"empty call so compiler doesn't bug me about variables not used"
	self touch: searchBuffer; touch: matchSpacePtr; touch: matchSpaceSize; touch: length
