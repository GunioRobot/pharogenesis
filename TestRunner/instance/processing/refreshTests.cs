refreshTests
	| preselected |
         selectedSuite _ 0.
        selectedFailureTest _ 0.
        selectedErrorTest _ 0.
	preselected _ Set new.
	tests with: selectedSuites do: [ :t :f | f ifTrue: [ preselected add: t ]].
       tests _ self gatherTestNames.
	selectedSuites _ tests collect: [ :ea | preselected includes: ea ].
        self changed: #tests.
        self changed: #selectedFailureTest.             "added rew"
        self changed: #selectedErrorTest.               "added rew"
        self changed: #selectedSuite.
        self refreshWindow