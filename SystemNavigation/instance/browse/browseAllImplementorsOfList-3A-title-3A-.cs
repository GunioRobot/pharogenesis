browseAllImplementorsOfList: selectorList title: aTitle 
	"Create and schedule a message browser on each method that implements 
	the message whose selector is in the argument selectorList. For 
	example,  
	self new browseAllImplementorsOf: #(at:put: size).  
	1/16/96 sw: this variant adds the title argument.  
	1/24/96 sw: use a SortedCollection  
	2/1/96 sw: show normal cursor"
	| implementorLists flattenedList |
	implementorLists := selectorList
				collect: [:each | self allImplementorsOf: each].
	flattenedList := SortedCollection new.
	implementorLists
		do: [:each | flattenedList addAll: each].
	Cursor normal show.
	^ self browseMessageList: flattenedList name: aTitle