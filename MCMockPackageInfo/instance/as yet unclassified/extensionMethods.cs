extensionMethods
	^ Array with: (MethodReference new 
					setStandardClass: MCSnapshotTest 
					methodSymbol: #mockClassExtension)