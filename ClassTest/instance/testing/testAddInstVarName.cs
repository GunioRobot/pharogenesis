testAddInstVarName
	"self run: #testAddInstVarName"
	
	
	| tutu |
	tutu := Smalltalk at: #TUTU.
	tutu addInstVarName: 'x'.
	self assert: (tutu instVarNames = #('x')).
	tutu addInstVarName: 'y'.
	self assert: (tutu instVarNames = #('x' 'y'))
	
	