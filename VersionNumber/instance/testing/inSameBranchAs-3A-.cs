inSameBranchAs: aVersion

	| less more |
	(aVersion numbers size <= numbers size) 
		ifTrue: [less := aVersion numbers. more := numbers] 
		ifFalse: [less := numbers. more := aVersion numbers].

	1 to: (less size - 1) do: [ :in | ((less at: in) = (more at: in)) ifFalse: [^false]].
	^less size = more size or:
		[(less at: less size) <= (more at: less size)]
