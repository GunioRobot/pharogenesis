testMacFileFullPathFor
	"(self run: #testMacFileFullPathFor)"

	SmalltalkImage current  platformName = 'Mac OS' 
		ifTrue: 
			[self 
				assert: (MacFileDirectory isAbsolute: (FileDirectory default 
								fullPathFor: FileDirectory default fullName)).
			self 
				deny: (MacFileDirectory isAbsolute: (FileDirectory on: 'Data') pathName)]