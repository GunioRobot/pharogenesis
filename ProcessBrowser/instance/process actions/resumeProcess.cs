resumeProcess
	| priority |
	selectedProcess
		ifNil: [^ self].
	priority _ self class suspendedProcesses
				removeKey: selectedProcess
				ifAbsent: [selectedProcess priority].
	selectedProcess priority: priority.
	selectedProcess resume.
	self updateProcessList