testCategorizing
	categorizer file: 37 inCategory: 'aardvark'.
	self assert: (categorizer at: 'aardvark') asSortedCollection asArray = {37}.
	categorizer file: 42 inCategory: 'aardvark'.
	self assert: (categorizer at: 'aardvark') asSortedCollection asArray = {37. 42}.
	
	categorizer file: 678 inCategory: 'banana'.
	self assert: (categorizer at: 'banana') asSortedCollection asArray = {678}.
	
	"Now let's try putting a message into two different categories."
	categorizer file: 42 inCategory: 'banana'.
	self assert: (categorizer at: 'aardvark') asSortedCollection asArray = {37. 42}.
	self assert: (categorizer at: 'banana') asSortedCollection asArray = {42. 678}.
