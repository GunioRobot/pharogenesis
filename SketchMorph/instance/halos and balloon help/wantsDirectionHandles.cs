wantsDirectionHandles
	^self valueOfProperty: #wantsDirectionHandles ifAbsent:[
		Preferences showDirectionHandles or:[Preferences showDirectionForSketches]]