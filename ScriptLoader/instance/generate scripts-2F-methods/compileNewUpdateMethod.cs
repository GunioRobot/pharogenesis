compileNewUpdateMethod
	"Use me to create a new update method with the next update number"
	"self new compileNewUpdateMethod"
	

	self class compile: 
		(self generateNewUpdateMethod)
		classified: 'pharo - updates'