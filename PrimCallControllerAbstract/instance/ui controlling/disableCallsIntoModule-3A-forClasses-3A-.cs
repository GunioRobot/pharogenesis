disableCallsIntoModule: aModule forClasses: classes 
	"Disables enabled external prim calls in aModule for classes."
	| methods |
	methods := self methodsWithEnabledCallIntoModule: aModule forClasses: classes.
	self changeStatusOfFailedCallsFlag
		ifTrue: [methods
				addAll: (self methodsWithFailedCallIntoModule: aModule forClasses: classes)].
	methods isEmpty
		ifTrue: [^ self error: 'no enabled '
					, (self changeStatusOfFailedCallsFlag	ifTrue: ['or failed ']	ifFalse: [''])
					, 'prim calls for module ' , aModule , ' in given classes found'].
	methods
		do: [:mRef | self disableCallIn: mRef]