shiftedYellowButtonActivity: shiftMenu
	"Present the alternate (shifted) menu and take action accordingly.  If we get here, shiftMenu is known to be non-nil.  "

	| index  |

	(index _ shiftMenu startUp) ~= 0
		ifTrue:
			[self menuMessageReceiver performMenuMessage: (self shiftedYellowButtonMessages at: index)]
		ifFalse:
			[super controlActivity]