isActiveDirectoryClass
	^ super isActiveDirectoryClass
		and: [(SmalltalkImage current getSystemAttribute: 1201) isNil
				or: [(SmalltalkImage current getSystemAttribute: 1201) asNumber <= 31]]