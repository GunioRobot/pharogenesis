removeEverythingInSetFromSystem: aChangeSet 

	aChangeSet changedMessageList
		do: [:methodRef | methodRef actualClass removeSelector: methodRef methodSymbol].
	aChangeSet changedClasses
		do: [:each | each isMeta
				ifFalse: [each removeFromSystemUnlogged]]