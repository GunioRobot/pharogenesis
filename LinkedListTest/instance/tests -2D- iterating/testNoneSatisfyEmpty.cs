testNoneSatisfyEmpty

	self assert: ( self empty noneSatisfy: [:each | false]).
	