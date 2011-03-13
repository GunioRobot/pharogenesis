messages
	^ (((self theClass
				compiledMethodAt: self selector 
				ifAbsent: [^ #()]) messages) asSortedArray)
					collect: [:sel | OBMessageNode 
									on: sel 
									inMethod: selector 
									inClass: self theClass]