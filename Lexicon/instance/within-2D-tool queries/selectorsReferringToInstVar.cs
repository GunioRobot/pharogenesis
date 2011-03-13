selectorsReferringToInstVar
	"Return a list of methods that refer to a given inst var that are in the protocol of this object"

	| aList  |
	aList := OrderedCollection new.
	targetClass withAllSuperclassesDo: [:aClass | 
		(aClass whichSelectorsAccess: currentQueryParameter asString) do: [:sel | 
			sel isDoIt ifFalse: [aList add: sel]
		]
	].
	^ aList