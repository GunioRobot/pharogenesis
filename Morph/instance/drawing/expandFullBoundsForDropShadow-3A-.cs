expandFullBoundsForDropShadow: aRectangle
	"Return an expanded rectangle for an eventual drop shadow"
	| delta box |

	box _ aRectangle.
	delta _ self shadowOffset.
	box _ delta x >= 0 
		ifTrue:[box right: aRectangle right + delta x]
		ifFalse:[box left: aRectangle left + delta x].
	box _ delta y >= 0
		ifTrue:[box bottom: aRectangle bottom + delta y]
		ifFalse:[box top: aRectangle top + delta y].
	^box