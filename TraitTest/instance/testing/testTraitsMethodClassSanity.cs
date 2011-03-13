testTraitsMethodClassSanity
	"self debug: #testTraitsMethodClassSanity"
	
	(Smalltalk allTraits gather: #users) asSet do: [ :each |
		each selectorsDo: [ :selector |
			self assert: [ (each >> selector) methodClass == each ] ] ]