windowsIn: aWorld satisfying: windowBlock
	| windows s |

	windows _ OrderedCollection new.
	aWorld ifNil: [^windows].	"opening MVC in Morphic - WOW!"
	aWorld submorphs do:
		[:m |
		((m isKindOf: SystemWindow) and: [windowBlock value: m])
			ifTrue: [windows addLast: m]
			ifFalse: [((m isKindOf: TransformationMorph) and: [m submorphs size = 1])
					ifTrue: [s _ m firstSubmorph.
							((s isKindOf: SystemWindow) and: [windowBlock value: s])
								ifTrue: [windows addLast: s]]]].
	^ windows