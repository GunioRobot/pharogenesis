browseClassCommentsWithString: aString
	"Smalltalk browseClassCommentsWithString: 'my instances' "
	"Launch a message list browser on all class comments containing aString as a substring."

	| caseSensitive suffix list |

	suffix _ (caseSensitive _ Sensor shiftPressed)
		ifTrue: [' (case-sensitive)']
		ifFalse: [' (use shift for case-sensitive)'].
	list _ Set new.
	Cursor wait showWhile: [
		Smalltalk allClassesDo: [:class | 
			(class organization classComment asString findString: aString 
							startingAt: 1 caseSensitive: caseSensitive) > 0 ifTrue: [
								list add: (
									MethodReference new
										setStandardClass: class
										methodSymbol: #Comment
								)
							]
		]
	].
	^ self 
		browseMessageList: list asSortedCollection
		name: 'Class comments containing ' , aString printString , suffix
		autoSelect: aString