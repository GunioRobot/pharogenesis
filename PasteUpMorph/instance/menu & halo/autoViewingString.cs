autoViewingString
	"Answer the string to be shown in a menu to represent the  
	automatic-viewing status"
	^ (self automaticViewing
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, 'automatic viewing' translated