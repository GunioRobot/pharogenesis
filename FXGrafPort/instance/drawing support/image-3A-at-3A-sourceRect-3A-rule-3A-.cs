image: aForm at: aPoint sourceRect: sourceRect rule: rule
	"Draw the portion of the given Form defined by sourceRect at the given point using the given BitBlt combination rule."
	(sourceMap isNil and:[destMap isNil and:[colorMap isNil and:[fillPattern isNil]]]) ifTrue:[
		"Let's try it the fast way if possible"
		(destForm isBltAccelerated: rule for: aForm) ifTrue:[
			^destForm 
				copyBits: sourceRect truncated
				from: aForm 
				at: aPoint asIntegerPoint
				clippingBox: self clipRect truncated
				rule: rule 
				fillColor: fillPattern 
				map: colorMap]].
	sourceForm _ aForm.
	combinationRule _ rule.
	self sourceRect: sourceRect.
	self destOrigin: aPoint.
	self copyBits