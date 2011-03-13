invoke
	"Install all methods changed here into method dictionaries.
	Make my versions be the ones that will be called."

	isolatedHead ifFalse: [^ self error: 'This isnt an isolation layer.'].
	inForce ifTrue: [^ self error: 'This layer is already in force.'].
	changeSet invoke.	
	inForce := true.