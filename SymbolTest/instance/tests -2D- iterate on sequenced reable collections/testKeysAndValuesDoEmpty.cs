testKeysAndValuesDoEmpty
	| result |
	result:= OrderedCollection new.
	
	self empty  keysAndValuesDo: 
		[:i :value|
		result add: (value+i)].
	
	self assert: result isEmpty .