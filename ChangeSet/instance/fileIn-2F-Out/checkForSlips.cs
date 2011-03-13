checkForSlips
	"Return a collection of method refs with possible debugging code in them."
	| slips tsRef changes method |
	slips _ OrderedCollection new.
	tsRef _ Smalltalk associationAt: #Transcript.
	self changedClasses do:
		[:aClass |
		changes _ methodChanges at: aClass name ifAbsent: [nil].
		changes ifNotNil:
			[changes associationsDo: 
				[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
					[method _ aClass compiledMethodAt: mAssoc key ifAbsent: [nil].
					method ifNotNil:
						[((method hasLiteral: #halt) or: [method hasLiteral: tsRef])
							ifTrue: [slips add: aClass name , ' ' , mAssoc key]]]]]].
	^ slips