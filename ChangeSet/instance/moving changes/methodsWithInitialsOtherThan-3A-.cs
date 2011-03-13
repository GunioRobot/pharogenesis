methodsWithInitialsOtherThan: myInits
	"Return a collection of method refs whose author appears to be different from the given one"
	| slips method aTimeStamp |
	slips _ OrderedCollection new.
	self changedClasses do:
		[:aClass |
		(self methodChangesAtClass: aClass name) associationsDo: 
				[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
					[method _ aClass compiledMethodAt: mAssoc key ifAbsent: [nil].
					method ifNotNil:
						[((aTimeStamp _ Utilities timeStampForMethod: method) notNil and:
							[(aTimeStamp beginsWith: myInits) not])
								ifTrue: [slips add: aClass name , ' ' , mAssoc key]]]]].
	^ slips

	"Smalltalk browseMessageList: (Smalltalk changes methodsWithInitialsOtherThan: 'sw') name: 'authoring problems'"