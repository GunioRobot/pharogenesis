assert: aBool 
	self
		debugCode: 
			[aBool
				ifFalse: 
					[self msg: 'Assertion failed!'.
					self cCode: 'exit(1)'
						inSmalltalk: 
							[interpreterProxy primitiveFail.
							self halt]].
			^ true]