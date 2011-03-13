actualClass 

	| actualClass |

	actualClass _ Smalltalk at: classSymbol ifAbsent: [^nil].
	classIsMeta ifTrue: [^actualClass classSide].
	^actualClass

