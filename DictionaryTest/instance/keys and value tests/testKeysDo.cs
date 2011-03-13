testKeysDo
	"self run: #testKeysDo"
	"self debug: #testKeysDo"
	
	| dict res |
	dict := Dictionary new.
	
	dict at: #a put: 33.
	dict at: #b put: 66.
	
	res := OrderedCollection new.
	dict keysDo: [ :each | res add: each].
	
	self assert: res asSet = #(a b) asSet.


	
	