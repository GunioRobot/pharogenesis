definition
	"Our superclass is really nil, but this causes problems when we try to become compact
	after filing in for the first time.  Fake the superclass as Object, and repair the situation
	during class initialisation."
	| defn |
	defn := super definition.
	^(defn beginsWith: 'nil ')
		ifTrue: ['Object' , (defn copyFrom: 4 to: defn size)]
		ifFalse: [defn].