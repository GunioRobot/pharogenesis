shiftedYellowButtonActivity
	"Present the alternate (shifted) menu and take action accordingly.  1/17/96 sw.
	1/25/96 sw: let #shiftedYellowButtonActivity: do the work"

	| index shiftMenu |

	(shiftMenu _ self shiftedYellowButtonMenu) == nil ifTrue:
		[^ super controlActivity].
	self shiftedYellowButtonActivity: shiftMenu