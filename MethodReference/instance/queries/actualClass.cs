actualClass 

	| actualClass |

	actualClass _ Smalltalk atOrBelow: classSymbol ifAbsent: [^nil].
	classIsMeta ifTrue: [^actualClass class].
	^actualClass

