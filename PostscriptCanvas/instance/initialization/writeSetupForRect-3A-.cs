writeSetupForRect:aRect
	target translate: psBounds origin.
	target translate: 0 @ aRect extent y;
			scale:1 @ -1;
		print:' [ {true setstrokeadjust} stopped ] pop
[ currenttransfer /exec cvx 1.2 /exp cvx ] cvx bind  settransfer'; cr.



