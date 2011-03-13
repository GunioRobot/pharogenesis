selectorsDefiningInstVar
	"Return a list of methods that define a given inst var that are in the protocol of this object"

	| aList  |
	aList := OrderedCollection new.
	targetClass withAllSuperclassesDo:
		[:aClass | 
			(aClass whichSelectorsStoreInto: currentQueryParameter asString) do: 
				[:sel | sel isDoIt ifFalse: [aList add: sel]
			]
		].
	^ aList