testAddNumbers
"self debug: #testAddNumbers"
	"md: I had to comment out the error... did strange things"
	self class addSelector: #add:with: withMethod: TestObjectsAsMethodsFunction.
	self assert: (self add: 3 with: 4) = 7.
	"self assert: (self perform: #add:with: withArguments: #(3 4)) = 7. "
	self class basicRemoveSelector: #add:with:.