testAtAllPutAll

	| valueArray |
	valueArray := self valueArray .
	self nonEmpty atAll: self indexArray putAll: valueArray  .
	
	1 to: self indexArray size do:
		[:i |
		self assert: (self nonEmpty at:(self indexArray at: i))= (valueArray  at:i) ]