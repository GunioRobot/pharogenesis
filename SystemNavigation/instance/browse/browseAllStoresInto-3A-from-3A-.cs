browseAllStoresInto: instVarName from: aClass
	"Create and schedule a Message Set browser for all the receiver's methods 
	or any methods of a subclass/superclass that refer to the instance variable name."
	
	"self new browseAllStoresInto: 'contents' from: Collection."

	| coll |
	coll _ OrderedCollection new.
	Cursor wait showWhile: [
		aClass withAllSubAndSuperclassesDo: [:class | 
			(class whichSelectorsStoreInto: instVarName) do: [:sel |
				sel isDoIt ifFalse: [
					coll add: (
						MethodReference new
							setStandardClass: class 
							methodSymbol: sel
					)
				]
			]
		].
	].
	^ self
		browseMessageList: coll 
		name: 'Stores into ' , instVarName 
		autoSelect: instVarName