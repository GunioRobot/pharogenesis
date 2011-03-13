listFromResult: resultOC
	"ResultOC is of the form #('(data1 op data2)' '(...)'). Answer a sorted array."

	(resultOC first beginsWith: 'no single method') ifTrue: [^ #()].
	^ resultOC sortBy: [:a :b | 
		(a copyFrom: 6 to: a size) < (b copyFrom: 6 to: b size)].

