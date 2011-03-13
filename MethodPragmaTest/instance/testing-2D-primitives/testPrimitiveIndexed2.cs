testPrimitiveIndexed2
	"This test useses the #asOop primitive."

	self compile: '<primitive: 75> ^ #oop' selector: #oop.
	self assert: self oop = self asOop.