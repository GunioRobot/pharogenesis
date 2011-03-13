writeSetupForRect:aRect
	target print:'% psBounds origin'; cr.
	target translate: psBounds origin.
	target print:'% flip'; cr.
	target translate: 0 @ 
		(aRect extent y * (EPSCanvas bobsPostScriptHacks ifTrue: [initialScale] ifFalse: [1]));
		scale:initialScale @ initialScale negated;
		print:' [ {true setstrokeadjust} stopped ] pop
[ currenttransfer /exec cvx 1.2 /exp cvx ] cvx bind  settransfer'; cr.



