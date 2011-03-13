defaultName
	| namesInUse try |
	namesInUse _ ChangeSorter gatherChangeSets
					collect: [:each | each name].
	1 to: 999999 do:
		[:i | try _ 'Unnamed' , i printString.
		(namesInUse includes: try) ifFalse: [^ try]]