autoBind: name 
	"Declare a block argument as a temp if not already declared."
	| node |
	node _ scopeTable 
			at: name
			ifAbsent: 
				[(self lookupInPools: name ifFound: [:assoc | assoc])
					ifTrue: [self notify: 'Name already used in a Pool or Global'].
				^ (self reallyBind: name) nowHasDef nowHasRef scope: 1].
	node isTemp
		ifTrue: [node scope >= 0 ifTrue:
					[^ self notify: 'Name already used in this method'].
				node nowHasDef nowHasRef scope: 1]
		ifFalse: [^ self notify: 'Name already used in this class'].
	^node