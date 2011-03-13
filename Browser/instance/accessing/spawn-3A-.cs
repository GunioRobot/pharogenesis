spawn: aString 
	"Create and schedule a new browser as though the command browse were 
	issued with respect to one of the browser's lists. The initial textual 
	contents is aString, which is the (modified) textual contents of the 
	receiver."

	messageListIndex ~= 0 
		ifTrue: [^self buildMessageBrowserEditString: aString].
	messageCategoryListIndex ~= 0 
		ifTrue: [^self buildMessageCategoryBrowserEditString: aString].
	classListIndex ~= 0 ifTrue: [^self buildClassBrowserEditString: aString].
	systemCategoryListIndex ~= 0 
		ifTrue: [^self buildSystemCategoryBrowserEditString: aString].
	^Browser new openEditString: aString