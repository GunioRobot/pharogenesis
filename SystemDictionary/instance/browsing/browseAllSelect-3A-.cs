browseAllSelect: aBlock
	"Create and schedule a message browser on each method that, when used 
	as the block argument to aBlock gives a true result. For example, 
	Smalltalk browseAllSelect: [:method | method numLiterals > 10]."

	^self browseMessageList: (self allSelect: aBlock) name: 'selected messages'