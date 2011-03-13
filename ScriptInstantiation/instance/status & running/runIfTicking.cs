runIfTicking
	status == #ticking ifTrue:
		[player perform: selector]