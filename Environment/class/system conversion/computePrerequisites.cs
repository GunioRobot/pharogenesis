computePrerequisites
	"We say one environment is a prerequisite of another if classes defined  
	in the other inherit from classes in the first.  
	Compute a dictionary with an entry for every non-kernel environment. 
	That entry is another dictionary giving the names of any prerequisite  
	environments and the list of classes that require it."
	"Environment computePrerequisites."
	"<-- inspect this"
	| bigCats bigCat preReqs supCat dict kernelCategories |
	bigCats _ IdentityDictionary new.
	kernelCategories _ Environment new kernelCategories.
	self flag: #NotSureOfTheSmalltalkReference. "sd"
	Smalltalk allClasses
		do: [:cl | 
			bigCat _ (cl category asString copyUpTo: '-' first) asSymbol.
			(kernelCategories includes: bigCat)
				ifTrue: [bigCat _ #Kernel].
			bigCats at: cl name put: bigCat].
	preReqs _ IdentityDictionary new.
	self flag: #NotSureAboutTheSmalltalkReferenceHere.
	"sd"
	Smalltalk allClasses
		do: [:cl | cl superclass
				ifNotNil: [bigCat _ bigCats at: cl name.
					supCat _ bigCats at: cl superclass name.
					bigCat ~~ supCat
						ifTrue: [dict _ preReqs
										at: bigCat
										ifAbsent: [preReqs at: bigCat put: IdentityDictionary new].
							dict
								at: supCat
								put: ((dict
										at: supCat
										ifAbsent: [Array new])
										copyWith: cl name)]]].
	^ preReqs