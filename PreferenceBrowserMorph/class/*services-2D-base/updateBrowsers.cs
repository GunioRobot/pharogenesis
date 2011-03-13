updateBrowsers

	(self allInstances select: [:e | e visible]) 
		do: [:each | 
			(each  findDeepSubmorphThat:[:m | m  isKindOf:PluggableListMorph]
				ifAbsent:[^ self]) verifyContents].