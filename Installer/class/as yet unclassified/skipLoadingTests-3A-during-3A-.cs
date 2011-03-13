skipLoadingTests: yesNo during: block

	| oldValue |

	oldValue := SkipLoadingTests.
	SkipLoadingTests := yesNo.
	
	block ensure:[ SkipLoadingTests := oldValue ].