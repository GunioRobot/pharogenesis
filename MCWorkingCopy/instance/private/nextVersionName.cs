nextVersionName
	| branch oldName |
	ancestry ancestors isEmpty
		ifTrue: [counter ifNil: [counter := 0]. branch := package name]
		ifFalse:
			[oldName := ancestry ancestors first name.
			oldName last isDigit
				ifFalse: [branch := oldName]
				ifTrue: [branch := oldName copyUpToLast: $-].
			counter ifNil: [
				counter := (ancestry ancestors collect: [:each |
					each name last isDigit
						ifFalse: [0]
						ifTrue: [(each name copyAfterLast: $-) extractNumber]]) max]].

	counter := counter + 1.
	^ branch, '-',  Utilities authorInitials, '.', counter asString