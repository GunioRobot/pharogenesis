showResult

	self errorLog cr;cr; show: '==== SUnit ======== Start ===='.
	self
		showResultSummary;
		showResultDefects.
	self errorLog cr; show: '==== SUnit ========== End ===='; cr.