compileUnlogged: text classified: category notifying: requestor 

	self deprecated: 'Use compileSilently:classified:notifying: instead.'.
	^ self compileSilently: text classified: category notifying: requestor.

"
	| selector  |
	self compile: text asString
		notifying: requestor
		trailer: #(0 0 0 0)
		ifFail: [^ nil]
		elseSetSelectorAndNode: 
			[:sel :node | selector _ sel].
	self organization classify: selector under: category.
	^ selector
"