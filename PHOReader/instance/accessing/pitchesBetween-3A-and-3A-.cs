pitchesBetween: t1 and: t2
	| step |
	step _ (t2 - t1 / 0.035) asInteger + 1. "step small enough"
	^ (t1 to: t2 by: t2 - t1 / step) collect: [ :each | each - t1 @ (self pitchAt: each)]