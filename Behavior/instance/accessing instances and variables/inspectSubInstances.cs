inspectSubInstances 
	"Inspect all instances of the receiver and all its subclasses.  CAUTION - don't do this for something as generic as Object!  1/26/96 sw"

	| all allSize prefix |
	all _ self allSubInstances.
	(allSize _ all size) == 0 ifTrue: [^ self notify: 'There are no 
instances of ', self name, '
or any of its subclasses'].
	prefix _ allSize == 1
		ifTrue: 	['The lone instance']
		ifFalse:	['The ', allSize printString, ' instances'].
	
	all asArray inspectWithLabel: (prefix, ' of ', self name, ' & its subclasses')