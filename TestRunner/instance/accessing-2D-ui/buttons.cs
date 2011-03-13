buttons
	^ #(( 'Run Selected' #runAll #hasRunnable )
		( 'Run Profiled' #runProfiled #hasRunnable )
		( 'Run Failures' #runFailures #hasFailures )
		( 'Run Errors' #runErrors #hasErrors )).