runCase: aTestCase
	| testCasePassed |
	testCasePassed := true.
	[[aTestCase runCase] 
			sunitOn: self class failure
			do: 
				[:signal | 
				failures add: aTestCase.
				testCasePassed := false.
				signal sunitExitWith: false]]
					sunitOn: self class error
					do:
						[:signal |
						errors add: aTestCase.
						testCasePassed := false.
						signal sunitExitWith: false].
	testCasePassed ifTrue: [passed add: aTestCase]