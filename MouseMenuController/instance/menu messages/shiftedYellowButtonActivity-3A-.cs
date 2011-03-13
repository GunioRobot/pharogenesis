shiftedYellowButtonActivity: shiftMenu
	"Present the alternate (shifted) menu and take action accordingly.  If we get here, shiftMenu is known to be non-nil.  1/26/96 sw"

	| index  |

	(index _ shiftMenu startUpYellowButton) ~= 0
		ifTrue:
			[self menuMessageReceiver performMenuMessage: (self shiftedYellowButtonMessages at: index)]
		ifFalse:
			[super controlActivity]