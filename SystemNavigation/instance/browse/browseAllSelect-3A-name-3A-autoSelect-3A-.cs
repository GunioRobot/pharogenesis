browseAllSelect: aBlock name: aName autoSelect: autoSelectString 
	"Create and schedule a message browser on each method that, when used 
	as the block argument to aBlock gives a true result. Do not return an  
	#DoIt traces."
	"self new browseAllSelect: [:method | method numLiterals > 10] name:  
	'Methods with more than 10 literals' autoSelect: 'isDigit'"
	^ self
		browseMessageList: (self allMethodsNoDoitsSelect: aBlock)
		name: aName
		autoSelect: autoSelectString