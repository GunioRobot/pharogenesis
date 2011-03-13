methodsWithInitialsOtherThan: myInits
	"Return a collection of method refs whose author appears to be different from the given one"
	| slips method aTimeStamp |
	slips := OrderedCollection new.
	self changedClasses do:
		[:aClass |
		(self methodChangesAtClass: aClass name) associationsDo: 
				[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
					[method := aClass compiledMethodAt: mAssoc key ifAbsent: [nil].
					method ifNotNil:
						[((aTimeStamp := Utilities timeStampForMethod: method) notNil and:
							[(aTimeStamp beginsWith: myInits) not])
								ifTrue: [slips add: aClass name , ' ' , mAssoc key]]]]].
	^ slips

	"Smalltalk browseMessageList: (ChangeSet current methodsWithInitialsOtherThan: 'sw') name: 'authoring problems'"