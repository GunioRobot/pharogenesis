shiftedYellowButtonActivity
	"Present the alternate (shifted) menu and take action accordingly.  .
	: let #shiftedYellowButtonActivity: do the work"

	| index shiftMenu |

	(shiftMenu _ self shiftedYellowButtonMenu) == nil ifTrue:
		[^ super controlActivity].
	self shiftedYellowButtonActivity: shiftMenu