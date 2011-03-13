findOriginalSins
	| sinnedSelectors sinners checkedClasses |
	checkedClasses _ IdentitySet new.
	originalSinsPerSelector := IdentityDictionary new.
	rootClasses do: 
			[:rootClass | 
			rootClass withAllSuperclassesDo: [:superClass | 
				(checkedClasses includes: superClass) ifFalse: [
					checkedClasses add: superClass.
					sinnedSelectors := self sinsIn: superClass.
					sinnedSelectors do: 
							[:sinSel | 
							sinners := originalSinsPerSelector at: sinSel
										ifAbsentPut: [IdentitySet new].
							sinners add: superClass]]]]