disableCallsIntoModule: aModule 
	"Disables enabled external prim calls in aModule."
	| methods |
	methods := self methodsWithEnabledCallIntoModule: aModule.
	self changeStatusOfFailedCallsFlag
		ifTrue: [methods
				addAll: (self methodsWithFailedCallIntoModule: aModule)].
	methods isEmpty
		ifTrue: [^ self error: 'no enabled '
					, (self changeStatusOfFailedCallsFlag	ifTrue: ['or failed ']	ifFalse: [''])
					, 'prim calls for module ' , aModule , ' found'].
	methods
		do: [:mRef | self disableCallIn: mRef]