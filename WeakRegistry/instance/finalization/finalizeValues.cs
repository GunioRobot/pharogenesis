finalizeValues
	"Some of our elements may have gone away. Look for those and activate the associated executors."
	| finiObjects |
	finiObjects := nil.
	"First collect the objects."
	self protected:[
		valueDictionary associationsDo: [:assoc|
			assoc key ifNil: [
				finiObjects 
					ifNil: [finiObjects := OrderedCollection with: assoc value]
					ifNotNil: [finiObjects add: assoc value]]
		].
		finiObjects ifNotNil: [valueDictionary finalizeValues: finiObjects asArray].
	].
	"Then do the finalization"
	finiObjects ifNil: [^self].
	finiObjects do:[:each| each finalize].
