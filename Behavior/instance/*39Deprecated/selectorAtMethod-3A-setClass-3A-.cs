selectorAtMethod: method setClass: classResultBlock 
	"Answer both the message selector associated with the compiled method 
	and the class in which that selector is defined."

	| sel |

	self deprecated: 'please call #methodClass and #selector on the method'.

	sel _ self methodDict keyAtIdentityValue: method
				ifAbsent: 
					[superclass == nil
						ifTrue: 
							[classResultBlock value: self.
							^method defaultSelector].
					sel _ superclass selectorAtMethod: method setClass: classResultBlock.
					"Set class to be self, rather than that returned from 
					superclass. "
					sel == method defaultSelector ifTrue: [classResultBlock value: self].
					^sel].
	classResultBlock value: self.
	^sel