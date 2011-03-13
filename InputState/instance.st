Object
	subclass: #InputState
	instanceVariableNames:
		'x y bitState lshiftState rshiftState ctrlState lockState metaState keyboardQueue deltaTime baseTime timeProtect redButtonQueue redButtonPollCnt '
	classVariableNames: 'RshiftKey InputProcess LshiftKey BitMin InputSemaphore BitMax MinPollCnt LockKey CtrlKey '
	poolDictionaries: ''
	category: 'Kernel-Processes'