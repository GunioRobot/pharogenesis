methodsWithDisabledCall
	^ self methodsWithCompiledCall
		select: [:mRef | (mRef compiledMethod literals first at: 4)
				= -2]