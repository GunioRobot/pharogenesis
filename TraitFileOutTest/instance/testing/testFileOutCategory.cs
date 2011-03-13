testFileOutCategory
	"File out whole system category, delete all classes and traits and then
	file them in again."

	"self run: #testFileOutCategory"

	| file |
	SystemOrganization fileOutCategory: self categoryName.
	SystemOrganization removeSystemCategory: self categoryName.
	self deny: (Smalltalk keys includesAnyOf: #(CA CB TA TB TC TD)).
	[	file := FileStream readOnlyFileNamed: self categoryName , '.st'.
		file fileIn]
		ensure: [file close].

	self assert: (Smalltalk keys includesAllOf: #(CA CB TA TB TC TD)).

	ta := Smalltalk at: #TA.
	self assert: ta traitComposition asString = 'TB + TC @ {#cc->#c} - {#c}'.
	self assert: (ta methodDict keys includesAllOf: #(a b cc)).

	cb := Smalltalk at: #CB.
	self assert: cb traitComposition asString = 'TA'.
	self assert: (cb methodDict keys includesAllOf: #(cb a b cc)).

	"test classSide traitComposition of CB"

	self assert: cb classSide traitComposition asString =  'TA classTrait + TC'.
	self assert: (cb classSide methodDict keys includesAllOf: #(d c))
	