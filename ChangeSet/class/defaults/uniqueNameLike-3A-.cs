uniqueNameLike: aString

	| namesInUse try |

	namesInUse _ ChangeSorter gatherChangeSets collect: [:each | each name].
	1 to: 999999 do: [:i |
		try _ aString , i printString.
		(namesInUse includes: try) ifFalse: [^ try]
	]