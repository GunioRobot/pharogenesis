selectorsReferringToInstVar
	"Return a list of methods that refer to a given inst var that are in the protocol of this object"

	| aList  |
	aList _ OrderedCollection new.
	targetClass withAllSuperclassesDo:
		[:aClass | 
			(aClass whichSelectorsAccess: currentQueryParameter asString) do: 
				[:sel | sel ~~ #DoIt ifTrue:
					[aList add: sel]]].
	^ aList