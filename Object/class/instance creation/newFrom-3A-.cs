newFrom: aSimilarObject
	"Create an object that has similar contents to aSimilarObject.  If the classes have any instance varaibles with the same names, copy them across.  If this is bad for a class, override this method."
	| myInstVars similarInstVars any inst good |
	myInstVars _ self allInstVarNames.
	similarInstVars _ aSimilarObject class allInstVarNames.
	inst _ self new.
	myInstVars doWithIndex: [:each :index |
		good _ similarInstVars indexOf: each.
		good > 0 ifTrue: [
			inst instVarAt: index put: 
				(aSimilarObject instVarAt: good).
			any _ true]].
	any == nil ifTrue: ["not related at all"
		self subclassResponsibility].
	^ inst