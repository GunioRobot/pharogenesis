runIfTicking
	status == #ticking ifTrue:
		[1 to: self frequency do:
			[:i | player perform: selector]]