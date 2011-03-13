finalizeValues
	"Some of our elements may have gone away. Look for those and activate the associated executors."
	| finiObjects |
	finiObjects := nil.
	"First collect the objects."
	self protected:[
		valueDictionary associationsDo:[:assoc|
			assoc key isNil ifTrue:[
				finiObjects isNil 
					ifTrue:[finiObjects := OrderedCollection with: assoc value]
					ifFalse:[finiObjects add: assoc value]]
		].
		finiObjects isNil ifFalse:[valueDictionary finalizeValues: finiObjects asArray].
	].
	"Then do the finalization"
	finiObjects isNil ifTrue:[^self].
	finiObjects do:[:each| each finalize].
