vrmlProtoCopyValues
	self isMultiType ifFalse:[^self value vrmlProtoCopy].
	^self value collect:[:node| node vrmlProtoCopy].