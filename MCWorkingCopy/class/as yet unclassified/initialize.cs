initialize
	Smalltalk 
		at: #MczInstaller
		ifPresent: [:installer | self adoptVersionInfoFrom: installer].
	self updateInstVars