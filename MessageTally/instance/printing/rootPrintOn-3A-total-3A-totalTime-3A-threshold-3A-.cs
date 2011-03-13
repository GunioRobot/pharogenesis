rootPrintOn: aStream total: total totalTime: totalTime threshold: threshold

	| sons groups p |
	sons := self sonsOver: threshold.
	groups := sons groupBy: [ :aTally | aTally process] having: [ :g | true].
	groups do:[:g|
		sons := g asSortedCollection.
		p := g anyOne process.
		(reportOtherProcesses or: [ p notNil ]) ifTrue: [
			aStream nextPutAll: '--------------------------------'; cr.
			aStream nextPutAll: 'Process: ',  (p ifNil: [ 'other processes'] ifNotNil: [ p browserPrintString]); cr.
			aStream nextPutAll: '--------------------------------'; cr.
			(1 to: sons size) do:[:i | 
				(sons at: i) 
					treePrintOn: aStream
					tabs: OrderedCollection new
					thisTab: ''
					total: total
					totalTime: totalTime
					tallyExact: false
					orThreshold: threshold]].
	]