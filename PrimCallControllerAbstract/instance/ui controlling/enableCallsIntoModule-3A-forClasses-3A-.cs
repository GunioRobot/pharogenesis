enableCallsIntoModule: aModule forClasses: classes 
	"Enables disabled external prim calls in aModule for classes."
	| methods |
	methods := self methodsWithDisabledCallIntoModule: aModule forClasses: classes.
	self changeStatusOfFailedCallsFlag
		ifTrue: [methods
				addAll: (self methodsWithFailedCallIntoModule: aModule forClasses: classes)].
	methods isEmpty
		ifTrue: [^ self error: 'no disabled '
					, (self changeStatusOfFailedCallsFlag	ifTrue: ['or failed ']	ifFalse: [''])
					, 'prim calls for module ' , aModule , ' in given classes found'].
	methods
		do: [:mRef | self enableCallIn: mRef]