adjustedCenter
	"This horizontal adjustment is needed because we want the interior TextMorph to be centered within the visual balloon rather than simply within the BalloonMorph's bounding box.  Without this, balloon-help text would be a bit off-center"

	^ self center + (offsetFromTarget x sign * (5 @ 0))