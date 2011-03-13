copyWithTally: hitCount
	^ (MessageTally new class: class method: method)
		reportOtherProcesses: reportOtherProcesses;
		process: process;
		bump: hitCount