enableCallsIntoModule: aModule 
	"Enables disabled external prim calls in aModule."
	| methods |
	methods := self methodsWithDisabledCallIntoModule: aModule.
	self changeStatusOfFailedCallsFlag
		ifTrue: [methods
				addAll: (self methodsWithFailedCallIntoModule: aModule)].
	methods isEmpty
		ifTrue: [^ self error: 'no disabled '
					, (self changeStatusOfFailedCallsFlag	ifTrue: ['or failed ']	ifFalse: [''])
					, 'prim calls for module ' , aModule , ' found'].
	methods
		do: [:mRef | self enableCallIn: mRef]