setLength: aLength
	"Set the length of the receiver."

	| cost lengthToUse |

	self hasCostumeThatIsAWorld ifTrue:[^ self].

	((cost _ self costume) isLineMorph)
		ifTrue:
			[^ cost unrotatedLength: aLength].
	lengthToUse _ cost isRenderer
		ifTrue:
			[aLength / cost scaleFactor]
		ifFalse:
			[aLength].
	cost renderedMorph height: lengthToUse