initialize

	| pt ext oldR points |
	super initialize.
	borderWidth _ 1.
	borderColor _ Color black.
	pt _ 10@10.
	ext _ pt r.
	oldR _ ext.
	points _ 5.
	vertices _ (0 to: 359 by: (360//points//2)) collect: [:angle |
		(Point r: (oldR _ oldR = ext ifTrue: [ext*5//12] ifFalse:
[ext]) degrees: angle + pt degrees)
			+ (45@45)].
	self computeBounds