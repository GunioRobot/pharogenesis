methodsWithFailedCall
	"Returns all methods containing failed external prim calls."
	^ self methodsWithCompiledCall select: self blockSelectFailedCall