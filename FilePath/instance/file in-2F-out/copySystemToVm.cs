copySystemToVm

	(self class instVarNames includes: 'systemPathName') ifTrue: [
		vmPathName _ self instVarNamed: 'systemPathName'.
	].

