newNamed: aSymbol 
	"Answer an instance of me whose name is the argument, aSymbol."

	^(self class subclassOf: self) new
		superclass: Object
		methodDict: MethodDictionary new
		format: Object format
		name: aSymbol
		organization: (ClassOrganizer defaultList: Array new)
		instVarNames: nil
		classPool: nil
		sharedPools: nil