methodsWithEnabledCall
	"Returns all methods containing enabled external prim calls."
	^ self methodsWithCompiledCall
		select: [:mRef | (mRef compiledMethod literals first at: 4)
				>= 0]