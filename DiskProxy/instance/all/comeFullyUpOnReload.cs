comeFullyUpOnReload
	"Internalize myself into a fully alive object after raw loading
	from a DataStream. (See my class comment.)
	The sender (the DataStream facility) will substitute the answer for myself."
	| globalObj |

	globalObj _ Smalltalk at: globalObjectName
		ifAbsent: [^ self halt: 'can''t internalize'].
	Symbol hasInterned: constructorSelector ifTrue: [:selector |
		^ globalObj perform: selector
				withArguments: constructorArgs].
	^ nil 	"was not in proper form"