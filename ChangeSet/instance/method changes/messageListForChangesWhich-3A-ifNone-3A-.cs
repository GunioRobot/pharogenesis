messageListForChangesWhich: aBlock ifNone: ifEmptyBlock

	| answer |

	answer _ self changedMessageListAugmented select: [ :each |
		aBlock value: each actualClass value: each methodSymbol
	].
	answer isEmpty ifTrue: [^ifEmptyBlock value].
	^answer
