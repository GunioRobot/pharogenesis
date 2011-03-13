inspectAllInstances 
	"Inpsect all instances of the receiver.  1/26/96 sw"

	| all allSize prefix |
	all _ self allInstances.
	(allSize _ all size) == 0 ifTrue: [^ self notify: 'There are no 
instances of ', self name].
	prefix _ allSize == 1
		ifTrue: 	['The lone instance']
		ifFalse:	['The ', allSize printString, ' instances'].
	
	all asArray inspectWithLabel: (prefix, ' of ', self name)